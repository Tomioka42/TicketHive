using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TicketHive.Ui.Pages.Member
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

        public void OnPost()
        {


            if (!string.IsNullOrEmpty(Password) && Password == ConfirmPassword)
            {
                //TODO: Save Password for current user in database

            }
        }
    }
}
