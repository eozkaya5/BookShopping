//using BookShopping.Models.Context;
//using BookShopping.Models.ShoppingModel;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;

//namespace BookShopping.Repository
//{

//    public class BasketRepository/* : Repository<Basket>*/
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;
//        public BasketRepository(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }
//        //public BasketRepository(BookContext Context) : base(Context)
//        //{
//        //}
//        public void Add(Product product)
//        {
//           // var list=_httpContextAccessor.HttpContext.Session.GetObject<List<Product>>("basket");
//        }

//    }
//}
