using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using TicketHive.Ui.Data;

namespace TicketHive.Ui.Pages.Member
{
    public class UserPageModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;
        [BindProperty]
        public string? OldPassword { get; set; }

        [BindProperty]
        public string? NewPassword { get; set; }
        [BindProperty]
        public string? ConfirmPassword { get; set; }
        public string StatusMessage { get; set; } 

        public UserPageModel(SignInManager<IdentityUser> signInManager,ApplicationDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;
        }
        public void OnGet()
        {
        }

        public async Task OnPost()
        {   

            if (!string.IsNullOrEmpty(NewPassword) && NewPassword == ConfirmPassword)
            {
                //TODO: Save Password for current user in database

                IdentityUser currentUser = await signInManager.UserManager.FindByNameAsync(HttpContext.User.Identity.Name);

                var passwordChangeResult = await signInManager.UserManager.ChangePasswordAsync(currentUser, OldPassword, NewPassword);

                if(passwordChangeResult.Succeeded)
                {
                    StatusMessage = "Your password was changed successfully";
                }
                else
                {
                    StatusMessage = "Error, Please try again!";
                }
            }
        }
    }
}
