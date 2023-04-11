using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    }
}

