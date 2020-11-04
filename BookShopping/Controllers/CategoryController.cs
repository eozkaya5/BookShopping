using System;
using System.Linq;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ShoppingDbContext _context;
        public CategoryController(ShoppingDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var model = _context.Categories.ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category model)
        {
            try
            {               
                _context.Categories.Add(model);
                _context.SaveChanges();
              
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(model);
            }          
        }
    }
}
