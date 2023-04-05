using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketHive.Server.Data;

namespace TicketHive.Server.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext context;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserRepo(AppDbContext context, SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.signInManager = signInManager;
        }
    }
}
