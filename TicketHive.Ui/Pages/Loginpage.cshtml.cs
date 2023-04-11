using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TicketHive.Ui.Pages
{
    [BindProperties]
    public class LoginpageModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        [Required(ErrorMessage = "Username is rquired")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is rquired")]
        public string? Password { get; set; }
        public void OnGet()
        {
        }

        public LoginpageModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var signInResult = await signInManager.PasswordSignInAsync(Username!, Password!, false, false);

                if (signInResult.Succeeded)
                {
                    return Redirect("/Homepage");
                }
            }
            return Page();
        }
    }
}