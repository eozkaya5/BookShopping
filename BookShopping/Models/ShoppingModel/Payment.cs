using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel
{
    public class Payment
    {
        public int Id { get; set; }
        public string TotalFee { get; set; }
        public DateTime Date { get; set; }
        public List<Order> Orders { get; set; }
    }
}
