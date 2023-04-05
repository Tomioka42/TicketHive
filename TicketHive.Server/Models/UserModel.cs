
using Microsoft.AspNetCore.Identity;

namespace TicketHive.Server.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public List<BookingModel> Bookings { get; set; } = new();
    }
}
