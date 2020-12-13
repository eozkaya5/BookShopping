using System;
using System.Linq;
using BookShopping.Models.Authentication;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class CategoryController : Controller
    {
        readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        readonly ShoppingDbContext _context;
        public CategoryController(ShoppingDbContext context, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {          
            var model = _context.Categories.ToList();           
            return View(model);
        }      
        public IActionResult List(int id)
        {
            var model = _context.Categories.ToList();
            ViewBag.Name = id;
            return View(model);
        }
        [HttpGet]
         [Authorize (Roles ="eozkaya675@gmail.com")]
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
                TempData["create"] = "Kategori" + " " + model.Name + "" + " eklendi.";

                _context.SaveChanges();
              
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {          
            var delete = _context.Categories.Find(id);
            _context.Categories.Remove(delete);
            TempData["delete"] = "Kategori" +" " +delete.Name+ ""+ " Silindi.";
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
