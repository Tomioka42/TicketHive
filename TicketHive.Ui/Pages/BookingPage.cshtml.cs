using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TicketHive.Server.Data;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Pages.Display
{
    public class BookingPageModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        [BindProperty]
        public int EventId { get; set; }
        public string SearchInput { get; set; }

        public BookingPageModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EventModel> Events { get; set; }

        public void OnGet(string searchInput)
        {
            SearchInput = searchInput;

            Events = _dbContext.Events.ToList();
        }

        public IActionResult OnPost()
        {
            // Lägg till eventet med det bindade EventId:t i ShoppingCart-cookien

            // Hämta ShoppingCart-cookien

            string shoppingCartJson = HttpContext.Session.GetString("ShoppingCart");

            // Gör om cookie-strängen till ett Cart-objekt

            CartModel cart = new();
            cart.CartItems = new();
            if(!string.IsNullOrEmpty(shoppingCartJson))
            {
                cart = JsonSerializer.Deserialize<CartModel>(shoppingCartJson);   
            }

            // Hämta info om det klickade eventet från databasen

            EventModel clickedEvent = _dbContext.Events.FirstOrDefault(e => e.Id == EventId);

            // Skapa cookie-data från infon från det hämtade eventet

            if(cart!.CartItems.Any(c => c.EventId == EventId))
            {
                CartItemModel cartItem = cart.CartItems.First(c => c.EventId == EventId);

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


