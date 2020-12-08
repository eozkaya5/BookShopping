using BookShopping.Models.ShoppingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Repository.Repositories
{
    public class ProductRepository : Repository<Product>
    {

        public ProductRepository(BookContext Context) : base(Context)
        {
        }

    }
}
