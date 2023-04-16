using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TicketHive.Ui.Pages
{
    public class Basket : PageModel
    {

        private readonly AppDbContext context;

        private readonly SignInManager<IdentityUser> signInManager;

        [BindProperty]
        public CartModel? Cart { get; set; }

        [BindProperty(Name = "item_index")]
        public  int CartItemIndex { get; set; }

        [BindProperty(Name = "quantity")]
        public int CartItemQuantity { get; set; }

        [BindProperty(Name = "action")]
        public string Action { get; set; }

        public string? Currency { get; set; }
        public CartItemModel CartItem { get; set; }

        public Basket(SignInManager<IdentityUser> signInManager, AppDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;
        }
        public void OnGet()
        {

            string cartItemsJson = HttpContext.Session.GetString("ShoppingCart"); // Session cookie
           
            //string cartItemsJson = Request.Cookies["ShoppingCart"]; // Vanlig cookie

            if (!string.IsNullOrEmpty(cartItemsJson))
            {
                // Convert the JSON string to a list of cart items
                Cart = JsonSerializer.Deserialize<CartModel>(cartItemsJson);

            }
            else
            {
                // If the cookie doesn't exist, create a new empty cart
                Cart = new CartModel();
                Cart.CartItems = new List<CartItemModel>();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            string cartItemsJson = HttpContext.Session.GetString("ShoppingCart"); // Session cookie

            //string cartItemsJson = Request.Cookies["ShoppingCart"]; // Vanlig cookie

            if (!string.IsNullOrEmpty(cartItemsJson))
            {
                // Convert the JSON string to a list of cart items
                Cart = JsonSerializer.Deserialize<CartModel>(cartItemsJson);
            }

            switch (Action)
            {
                case "pay":

                    IdentityUser currentUser = await signInManager.UserManager.FindByNameAsync(HttpContext.User.Identity.Name);

                    foreach (CartItemModel cartItem in Cart.CartItems)
                    {
                        EventModel eventModel = context.Events.Find(cartItem.EventId);
                        if (eventModel.TotalTickets < (eventModel.TicketsSold + cartItem.Quantity))
                        {
                            return RedirectToPage("/member/basket", new { ticketsSoldOut = "true" });
                        }
                    }
                        foreach (CartItemModel cartItem in Cart.CartItems)
                    {

                        EventModel eventModel = context.Events.Find(cartItem.EventId);
                        BookingModel booking = new BookingModel();
                        booking.AmountOfTickets = cartItem.Quantity;
                        booking.UserId = currentUser.Id;
                        booking.Event = eventModel;
                        eventModel.TicketsSold += cartItem.Quantity;
                        context.ChangeTracker.DetectChanges();

                        context.Bookings.Add(booking);

                    }
                    context.SaveChanges();
                    return RedirectToPage("/ConfirmationPage");
                case "increase":
                    if (Cart != null && Cart.CartItems != null && CartItemIndex >= 0 && CartItemIndex < Cart.CartItems.Count)
                    {
                        Cart.CartItems[CartItemIndex].Quantity++;
                        SaveCartToCookie();
                    }
                    break;
                case "decrease":
                    if (Cart != null && Cart.CartItems != null && CartItemIndex >= 0 && CartItemIndex < Cart.CartItems.Count)
                    {
                        Cart.CartItems[CartItemIndex].Quantity--;

                        if (Cart.CartItems[CartItemIndex].Quantity <= 0)
                        {
                            Cart.CartItems.RemoveAt(CartItemIndex);
                        }
                        SaveCartToCookie();
                    }
                    break;
                case "delete":
                    if (Cart != null && Cart.CartItems != null && CartItemIndex >= 0 && CartItemIndex < Cart.CartItems.Count)
                    {
                        Cart.CartItems.RemoveAt(CartItemIndex);
                        SaveCartToCookie();
                    }
                    break;
                default:
                    if (Cart != null && Cart.CartItems != null && CartItemIndex >= 0 && CartItemIndex < Cart.CartItems.Count)
                    {
                        Cart.CartItems[CartItemIndex].Quantity = CartItemQuantity;
                        SaveCartToCookie();
                    }
                    break;
            }
            return RedirectToPage("/member/basket");
        }

        private void SaveCartToCookie()
        {
            string cartItemsJson = JsonSerializer.Serialize(Cart);
                
            HttpContext.Session.SetString("ShoppingCart", cartItemsJson); // Session cookie

            //Response.Cookies.Append("ShoppingCart", cartItemsJson); // Vanlig cookie
            Response.Redirect("/member/basket");
        }

       

    }
}
