using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel 
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<Picture> Pictures { get; set; }

        
    }
  
}
