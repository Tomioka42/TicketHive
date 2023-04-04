using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TicketHive.Server.Data;
using TicketHive.Server.Models;
using TicketHive.Ui.Repos;

namespace TicketHive.Ui.Repo
{
    public class EventRepo: IEventRepo
    {
        private readonly AppDbContext context;

        public EventRepo(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<List<EventModel>?> GetAllEvents()
        {
            var events = await context.Events.ToListAsync();

            if(events == null)
            {
                return null;
            }
            return events;
        }


        public async Task<ActionResult<EventModel>?> GetEvent(int id)
        {
            var reqEvent = await context.Events.FindAsync(id);

            if(reqEvent == null)
            {
                return null;
            }
            return reqEvent;

            //return await context.Events.FindAsync(id);
        }

        public async Task<ActionResult<EventModel>> PostEvents()
        {
            var response = await context.Events.ToListAsync();

            EventModel newEvent = new()
            {
                Name = response.Name
            };
        }
    }
}
