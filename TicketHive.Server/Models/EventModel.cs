namespace TicketHive.Server.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string EventType { get; set; } = null!;
        public int GuestCapacity { get; set; }
        public string? Location { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string? Image { get; set; }
        public int TotalTickets { get; set; }
        public int TicketsSold { get; set; }
        public bool IsSoldOut { get { return TicketsSold >= TotalTickets; } }


        public List<UserModel> Users { get; set; } = new();
    }
}
