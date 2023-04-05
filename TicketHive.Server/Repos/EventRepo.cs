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


        public ActionResult<EventModel>? GetEvent(int id)
        {
            var reqEvent = context.Events.Include(e => e.Users).FirstOrDefault(e => e.Id == id);

            if(reqEvent == null)
            {
                return null;
            }
            return reqEvent;

            //return await context.Events.FindAsync(id);
        }

        public ActionResult<EventModel> DeleteEvent(int id)
        {
            EventModel? eventToRemove = context.Events.FirstOrDefault(e => e.Id == id);

            if(eventToRemove == null)
            {
                return null!;
            }
            else
            {
                context.Events.Remove(eventToRemove);
                context.SaveChanges();

                return eventToRemove;
            }
        }


    }
}
