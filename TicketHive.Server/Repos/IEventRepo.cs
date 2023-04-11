
using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Repos
{
    public interface IEventRepo
    {
        Task <List<EventModel>?> GetAllEvents();

        Task<ActionResult<EventModel>?> GetEvent(int id);

        Task<ActionResult<EventModel>?> DeleteEvent(int id);
    }
}
