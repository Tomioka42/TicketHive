namespace TicketHive.Server.Models
{
    public class IdentityUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;

        public List<BookingModel> Bookings { get; set; } = new();
    }
}
