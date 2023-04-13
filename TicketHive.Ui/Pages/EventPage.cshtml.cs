using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using TicketHive.Server.Data;
using TicketHive.Server.Models;


namespace TicketHive.Ui.Pages
{
    public class EventPageModel : PageModel
    {
        private readonly AppDbContext _context;

        public EventModel Event { get; set; }

        public EventPageModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            Event = _context.Events.Find(id);

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id) 
        {
            string shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");

            CartModel cart = new();
            cart.CartItems = new();
            if (!string.IsNullOrEmpty(shoppingCartJson))
            {
                cart = JsonSerializer.Deserialize<CartModel>(shoppingCartJson);
            }

            EventModel clickedEvent = _context.Events.FirstOrDefault(e => e.Id == id);

            if (cart!.CartItems.Any(c => c.EventId == id))
            {
                CartItemModel cartItem = cart.CartItems.First(c => c.EventId == id);

                cartItem.Quantity++;
            }
            else
            {
                cart.CartItems.Add(new CartItemModel()
                {
                    EventId = clickedEvent.Id,
                    EventName = clickedEvent.Name,
                    Price = clickedEvent.TicketPrice,
                    EventType = clickedEvent.EventType,
                    Quantity = 1
                });
            }

            shoppingCartJson = JsonSerializer.Serialize(cart);

            HttpContext.Session.SetString("ShoppingCart", shoppingCartJson);

            return RedirectToPage("/member/basket");
        }
    }
}

