using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Pages
{
    public class Basket : PageModel
    {

        [BindProperty]
        public CartModel? Cart { get; set; }

        [BindProperty(Name = "item_index")]
        public  int CartItemIndex { get; set; }

        [BindProperty(Name = "quantity")]
        public int CartItemQuantity { get; set; }

        [BindProperty(Name = "action")]
        public String Action { get; set; }

        public void OnGet()
        {

            //TODO: Cart = Cart from session

            //TODO: remove below
            Cart = new CartModel();
            Cart.CartItems = new List<CartItemModel>();
            CartItemModel CartItem1 = new CartItemModel();
            CartItem1.EventName = "2pac";
            CartItem1.EventType = "Music";
            CartItem1.Quantity = 3;
            CartItem1.Price = 100;
            CartItemModel CartItem2 = new CartItemModel();
            CartItem2.EventName = "50 cent";
            CartItem2.EventType = "Tozz";
            CartItem2.Quantity = 5;
            CartItem2.Price = 250;
            Cart.CartItems.Add(CartItem1);
            Cart.CartItems.Add(CartItem2);


        }

        public void OnPost()
        {
            switch (Action)
            {
                case "increase":
                    //TODO: Increase CartItemIndex quantity with 1 and update price. Then save in session
                    break;
                case "decrease":
                    //TODO: Decrease CartItemIndex quantity with 1 and update price. Then save in session
                    break;
                case "delete":
                    //TODO:Delete CartItemIndex and save in session
                    break;
                default:
                    //TODO: Set quantity of CartItemIndex to CartItemQuantity and update price. Then save in session
                    break;
            }
            OnGet();
        }
    }
}
