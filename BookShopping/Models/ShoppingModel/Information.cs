using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookShopping.Models.ShoppingModel 
{
    public class Information
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

       
    }
}