using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Server.Data;
using TicketHive.Server.Models;

namespace TicketHive.Server.Repos
{
    public class BookingRepo : IBookingRepo
    {
        private readonly AppDbContext context;

        public BookingRepo(AppDbContext context)
        {
            this.context = context;
        }


        public async Task<List<BookingModel>?> GetAllBookings()
        {
            var bookings = await context.Bookings.ToListAsync();

            if(bookings == null || bookings.Count == 0)
            {
                return null;
            }
            return bookings;
        }

        public ActionResult<BookingModel?> GetBooking(int id)
        {
            var reqBooking = context.Bookings.Include(b => b.User).FirstOrDefault(b => b.Id == id);

            if(reqBooking == null)
            {
                return null;
            }
            return reqBooking;
        }

        public ActionResult<BookingModel>? DeleteBooking(int id)
        {
            BookingModel? bookingToRemove = context.Bookings.FirstOrDefault(b => b.Id == id);

            if(bookingToRemove == null)
            {
                return null;
            }
            else
            {
                context.Bookings.Remove(bookingToRemove);
                context.SaveChanges();

                return bookingToRemove;
            }
        }
    }
}
