using BookShopping.Models.Authentication;
using BookShopping.Models.ShoppingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping
{
    public class ViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<AppUser> appUsers { get; set; }

    }
}
