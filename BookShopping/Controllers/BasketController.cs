using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class BasketController : Controller
    {
        // GET: BasketController
        public ActionResult Index()
        {
            return View();
        }

    }
}
