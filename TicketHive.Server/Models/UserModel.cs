namespace TicketHive.Server.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<BookingModel> Bookings { get; set; } = new();
    }
}
