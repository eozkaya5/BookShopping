using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookShopping.Models;
using Microsoft.AspNetCore.Authorization;
using BookShopping.Models.ModelTypes;
using BookShopping.Models.Context;

namespace BookShopping.Controllers
{
   
    public class HomeController : Controller
    {
        readonly ShoppingDbContext _contex;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ShoppingDbContext context)
        {
            _logger = logger;
            _contex = context;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;
            ViewModel model = new ViewModel();
            model.HomePage = _contex.Products.ToList();
            model.SideBar = _contex.Categories.ToList();
            return View(model);
        }
        public IActionResult Errors()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
