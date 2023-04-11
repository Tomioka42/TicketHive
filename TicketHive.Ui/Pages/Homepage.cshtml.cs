using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Server.Repos;
using TicketHive.Ui.Repos;

namespace TicketHive.Ui.Pages
{
    public class HomepageModel : PageModel
    {
        private readonly IEventRepo repo;
        private readonly AppDbContext context;
        private readonly IBookingRepo bookingrepo;

        [BindProperty]
        public List<EventModel> Events { get; set; }
        public List<BookingModel> Bookings { get; set; }

        public HomepageModel(IEventRepo repo, AppDbContext context, IBookingRepo bookingrepo)
        {
            this.repo = repo;
            this.context = context;
            this.bookingrepo = bookingrepo;
        }
        public async Task<IActionResult> OnGet()
        {
            Events = await repo.GetAllEvents();

            Bookings = await bookingrepo.GetAllBookings();
            return Page();
        }
    }
}
