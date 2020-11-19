using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel 
{
    public class Basket
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalFee { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public List<Order> Orders { get; set; }
    }
}
