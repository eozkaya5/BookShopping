using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.Authentication 
{
    public class AppUser : IdentityUser<int>
    {


        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime Date { get; set; }
        public string Adress { get; set; }
    }
}