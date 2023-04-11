using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketHive.Server.Data;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Pages.Display
{
    public class BookingPageModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public BookingPageModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<EventModel> Events { get; set; }

        public void OnGet()
        {
            Events = _dbContext.Events.ToList();
        }

        
    }
    
    
}


