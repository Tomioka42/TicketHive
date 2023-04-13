using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Ui.Repos;

namespace TicketHive.Ui.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly AppDbContext context;
        private readonly IEventRepo repo;

        [BindProperty]
        public List<EventModel>? Events { get; set; }

        [BindProperty]
        public EventModel? NewEvent { get; set; }

        [BindProperty(Name = "new_date")]
        public String? NewDate { get; set; }
        [BindProperty(Name = "new_time")]
        public String? NewTime { get; set; }


        [BindProperty(Name = "event_id")]
        public int EventId { get; set; }
        public AdminPageModel(AppDbContext context, IEventRepo repo)
        {
            this.context = context;
            this.repo = repo;
        }

        public async Task OnGet()
        {

            //TODO: Events = List of events from database
            Events = await context.Events.ToListAsync();

            
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            NewEvent.DateTime =  DateTime.Parse(NewDate+" "+NewTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
            
            //TODO: Add NewEvent to database;
            EventModel newEvent = new()
            {
                Name = NewEvent.Name,
                EventType = NewEvent.EventType,
                DateTime = NewEvent.DateTime,
                Location = NewEvent.Location,
                TicketPrice = NewEvent.TicketPrice,
                GuestCapacity = NewEvent.GuestCapacity,
            };
            context.Events.Add(newEvent);
            await context.SaveChangesAsync();


            await OnGet();
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            await repo.DeleteEvent(EventId);

            await OnGet();
            return Page();
        }
        
    }
}
