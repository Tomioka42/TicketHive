using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TicketHive.Ui.Data;

namespace TicketHive.Ui.Pages
{
    [BindProperties]
    public class RegisterpageModel : PageModel
    {

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ApplicationDbContext context;

        [Required(ErrorMessage = "Username is requierd")]
        [MinLength(5, ErrorMessage = "Username must be at least 5 characters")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password is requierd")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string? Password { get; set; }

        public RegisterpageModel(SignInManager<IdentityUser> signInManager, ApplicationDbContext context)
        {
            this.signInManager = signInManager;
            this.context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            // Om alla props är bindade som de ska...
            if (ModelState.IsValid)
            {
                // Skapa en ny IdentityUser med användarnamnet som är inskrivet
                IdentityUser newUser = new()
                {
                    UserName = Username
                };

                // testa att registerera användaren med lösenordet den skrev in
                var registerResult = await signInManager.UserManager.CreateAsync(newUser, Password!);

                //Om registreningsförsöket lyckades...
                if (registerResult.Succeeded)
                {
                    context.Add(registerResult);
                    context.SaveChanges();
                    return Redirect("/Index");
                }

            }

            return Page();
        }
    }
}