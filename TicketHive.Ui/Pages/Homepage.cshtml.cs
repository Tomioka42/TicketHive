using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Ui.Repos;

namespace TicketHive.Ui.Pages
{
    public class HomepageModel : PageModel
    {
        private readonly IEventRepo repo;
        private readonly AppDbContext context;

        [BindProperty]
        public List<EventModel> Events { get; set; }

        public HomepageModel(IEventRepo repo, AppDbContext context)
        {
            this.repo = repo;
            this.context = context;
        }
        public async Task<IActionResult> OnGet()
        {
            Events = await repo.GetAllEvents();

            return Page();
        }
    }
}
