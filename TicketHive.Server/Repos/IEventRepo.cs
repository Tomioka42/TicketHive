
using Microsoft.AspNetCore.Mvc;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Repos
{
    public interface IEventRepo
    {
        Task <List<EventModel>?> GetAllEvents();

        ActionResult<EventModel>? GetEvent(int id);

        ActionResult<EventModel> DeleteEvent(int id);
    }
}
