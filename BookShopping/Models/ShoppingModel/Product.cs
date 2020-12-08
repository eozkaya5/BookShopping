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
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
      public string Picture { get; set; }
      //3  public string Picture { get { return $"/Images/_{Code}.jpg"; } }

        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public Category Category { get; set; }
        public List<Basket> Baskets { get; set; }
        public List<Picture> Pictures { get; set; }

        
    }
  
}
