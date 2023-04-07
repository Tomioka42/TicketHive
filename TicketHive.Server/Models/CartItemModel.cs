using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketHive.Server.Models
{
    public class CartItemModel
    {

        public int EventId { get; set; }
        public String EventName { get; set; }
        public String EventType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
