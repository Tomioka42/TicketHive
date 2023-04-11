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

        /// <summary>
        /// Hämtar alla bookings och lägger det till en lista asyncront.
        /// </summary>
        /// <returns></returns>

        public async Task<List<BookingModel>?> GetAllBookings()
        {
            var bookings = await context.Bookings.ToListAsync();

            if(bookings == null || bookings.Count == 0)
            {
                return null;
            }
            return bookings;
        }

        /// <summary>
        /// Hämtar en specifik booking med det Id som har angivits. Skickar även med användaren till bookningen.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<BookingModel>?> GetBooking(int id)
        {
            var reqBooking = await context.Bookings.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);

            if(reqBooking == null)
            {
                return null;
            }
            return reqBooking;
        }

        /// <summary>
        /// Tar bort en specifik booking med det Id:et som är angivit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<BookingModel>?> DeleteBooking(int id)
        {
            BookingModel? bookingToRemove = await context.Bookings.FirstOrDefaultAsync(b => b.Id == id);

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
