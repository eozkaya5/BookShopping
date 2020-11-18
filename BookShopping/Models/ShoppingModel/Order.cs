using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel 
{
    public class Order
    {
        public int Id { get; set; }
        public string Product { get; set; }
        public string Piece { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int CargoId { get; set; }
        public int BasketId { get; set; }      
        public int PaymentId { get; set; }

        public Cargo Cargo { get; set; }
        public Basket Basket { get; set; }
        public Payment Payment { get; set; }
    }
}
