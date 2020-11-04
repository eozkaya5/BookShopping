using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Road { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
