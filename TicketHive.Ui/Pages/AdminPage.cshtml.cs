using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Pages
{
    public class AdminPageModel : PageModel
    {
        [BindProperty]
        public List<EventModel> Events { get; set; }

        [BindProperty]
        public EventModel NewEvent { get; set; }

        [BindProperty(Name = "new_date")]
        public String NewDate { get; set; }
        [BindProperty(Name = "new_time")]
        public String NewTime { get; set; }


        [BindProperty(Name = "event_id")]
        public String? EventId { get; set; }

        public void OnGet()
        {

            //TODO: Events = List of events from database

            //TODO: remove below
            NewEvent = new EventModel();
            Events = new List<EventModel>();
            EventModel Event = new EventModel();
            Event.Name = "Bingo";
            Events.Add(Event);

            Event = new EventModel();
            Event.Name = "Bazz";
            Events.Add(Event);
        }

        public async Task<IActionResult> OnPostAddAsync()
        {
            
            NewEvent.DateTime =  DateTime.Parse(NewDate+" "+NewTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
            
            //TODO: Add NewEvent to database;

            OnGet();
            return Page();
        }
        public async Task<IActionResult> OnPostRemoveAsync()
        {
            //TODO: Remove EventId from database;
            OnGet();
            return Page();

        }
    }
}
