using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TicketHive.Data.Models;

namespace TicketHive.Data.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventModel>().HasData(new EventModel()
            {
                Id = 1,
                Name = "Sweden Rock",
                EventType = "Music festival",
                GuestCapacity = 35000,
                Location = "Sölvesborg",
                TicketPrice = 600m,
                DateTime = new DateTime(2024, 6, 7)
            },
            new EventModel
            {
                Id = 2,
                Name = "Coachella Music Festival",
                EventType = "Music festival",
                GuestCapacity = 125000,
                Location = "Indio, California",
                TicketPrice = 429.99m,
                DateTime = new DateTime(2024, 4, 14)
            },
            new EventModel
            {
                Id = 3,
                Name = "Oktoberfest",
                EventType = "Beer festival",
                GuestCapacity = 6000,
                Location = "Munich, Germany",
                TicketPrice = 50m,
                DateTime = new DateTime(2024, 9, 16)
            },
            new EventModel
            {
                Id = 4,
                Name = "Burning Man",
                EventType = "Art festival",
                GuestCapacity = 70000,
                Location = "Black Rock City, Nevada",
                TicketPrice = 475m,
                DateTime = new DateTime(2024, 8, 27)
            },
            new EventModel
            {
                Id = 5,
                Name = "San Diego Comic-Con",
                EventType = "Entertainment convention",
                GuestCapacity = 135000,
                Location = "San Diego, California",
                TicketPrice = 150m,
                DateTime = new DateTime(2024, 7, 19)
            },
            new EventModel
            {
                Id = 6,
                Name = "Winter Olympics",
                EventType = "Sports event",
                GuestCapacity = 2500,
                Location = "Beijing, China",
                TicketPrice = 250m,
                DateTime = new DateTime(2026, 2, 6)
            },
            new EventModel
            {
                Id = 7,
                Name = "Cannes Film Festival",
                EventType = "Film festival",
                GuestCapacity = 40000,
                Location = "Cannes, France",
                TicketPrice = 50m,
                DateTime = new DateTime(2024, 5, 16)
            },
            new EventModel
            {
                Id = 8,
                Name = "Mardi Gras",
                EventType = "Carnival",
                GuestCapacity = 1000000,
                Location = "New Orleans, Louisiana",
                TicketPrice = 300m,
                DateTime = new DateTime(2024, 2, 13)
            },
            new EventModel
            {
                Id = 9,
                Name = "Consumer Electronics Show",
                EventType = "Technology convention",
                GuestCapacity = 170000,
                Location = "Las Vegas, Nevada",
                TicketPrice = 200m,
                DateTime = new DateTime(2024, 1, 9)
            },
            new EventModel
            {
                Id = 10,
                Name = "Wimbledon Tennis Championships",
                EventType = "Sports event",
                GuestCapacity = 39000,
                Location = "London, United Kingdom",
                TicketPrice = 500m,
                DateTime = new DateTime(2024, 7, 3)
            },
            new EventModel
            {
                Id = 11,
                Name = "Running of the Bulls",
                EventType = "Cultural event",
                GuestCapacity = 2000000,
                Location = "Pamplona, Spain",
                TicketPrice = 150m,
                DateTime = new DateTime(2024, 7, 7)
            },
            new EventModel
            {
                Id = 12,
                Name = "World Series",
                EventType = "Sports event",
                GuestCapacity = 40000,
                Location = "Various cities",
                TicketPrice = 70000,
                DateTime = new DateTime(2024)
            });
        }
    }
}
