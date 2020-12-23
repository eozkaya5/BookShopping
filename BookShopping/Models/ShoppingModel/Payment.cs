using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel 
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal TotalFee { get; set; }
        public DateTime Date { get; set; }
        public int BasketId { get; set; }
        public int UserId { get; set; }

        public Basket Basket { get; set; }
       
    }
}
