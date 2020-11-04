using BookShopping.Models.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.Context
{
    public class LoginDbContext:IdentityDbContext<AppUser, AppRole, int>
    {
        public LoginDbContext(DbContextOptions<LoginDbContext>options) : base(options) { }
    }
}