using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Reflection.Emit;
using TicketHive.Server.Models;

namespace TicketHive.Ui.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<UserModel> Users { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<IdentityUserModel>().HasData(new IdentityUserModel()
        //    {
        //        Id = 1,
        //        Username = "admin",
        //        Password = "Password1234!"

        //    },
        //    new IdentityUserModel()
        //    {
        //        Id=2,
        //        Username="user",
        //        Password = "Password1234!"
        //    });
        //}
    }
}