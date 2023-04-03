namespace TicketHive.Server.Models
{
    public class BookingModel
    {
        // EventModel
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string EventType { get; set; } = null!;
        public int GuestCapacity { get; set; }
        public string? Location { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime DateTime { get; set; }

        // BookingModel
        public int AmountOfTickets { get; set; }
        public UserModel? User { get; set; }
    }
}
