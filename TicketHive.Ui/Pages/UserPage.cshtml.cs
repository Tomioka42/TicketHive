using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicketHive.Ui.Pages
{
    public class UserPageModel : PageModel
    {
        [BindProperty(Name = "password")]
        public string? Password { get; set; }
        [BindProperty(Name = "confirm_password")]
        public string? ConfirmPassword { get; set; }
        public void OnGet()
        {
        }

        public void OnPost() {
            
            
            if(!String.IsNullOrEmpty(Password) && Password == ConfirmPassword )
            {
                //TODO: Save Password for current user in database

            }
        }
    }
}
