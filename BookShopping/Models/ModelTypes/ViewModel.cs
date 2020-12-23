using BookShopping.Models.Authentication;
using BookShopping.Models.ShoppingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ModelTypes
{
    public class ViewModel
    {

        public IEnumerable<Product> HomePage { get; set; }
        public IEnumerable<Category> SideBar { get; set; }
        public IEnumerable<AppUser> UserApp { get; set; }
        public IEnumerable<UserComment> Comment { get; set; }
    }
}
    
