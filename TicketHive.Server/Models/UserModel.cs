namespace TicketHive.Server.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

        // Additional property for the second database
        public string AdditionalPassword { get; set; } = null!;

        public List<BookingModel> Bookings { get; set; } = new();
    }
}
