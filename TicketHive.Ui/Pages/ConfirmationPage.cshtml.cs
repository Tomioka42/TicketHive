using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using TicketHive.Server.Models;
using TicketHive.Server.Data;

namespace TicketHive.Ui.Pages
{
    public class ConfirmationPageModel : PageModel
    {
        private readonly ILogger<ConfirmationPageModel> _logger;

        public CartModel? Cart { get; set; }

        public ConfirmationPageModel(ILogger<ConfirmationPageModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string cartItemsJson = HttpContext.Session.GetString("ShoppingCart"); // Session cookie

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


            HttpContext.Session.Remove("ShoppingCart");
        }


    }
}
