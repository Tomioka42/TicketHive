using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Server.Models;

namespace TicketHive.Server.Repos
{
    public interface IBookingRepo
    {
        Task<List<BookingModel>> GetAllBookings();
        ActionResult<BookingModel?> GetBooking(int id);

        ActionResult<BookingModel>? DeleteBooking(int id);

    }
}
