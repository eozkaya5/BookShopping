using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShopping.Controllers
{

    public class ProductController : Controller
    {
        public readonly ShoppingDbContext _context;
        public ProductController(ShoppingDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int id)
        {
            var model = _context.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var todo = new Product { CategoryId = id };
            return View(todo);
        }
        [HttpPost]
        public IActionResult Create(Product shopping)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var payment = _context.Categories.Find(shopping.CategoryId);
                  
                    _context.Products.Add(shopping);
                    _context.SaveChanges();
                    return RedirectToAction("Index", new { id = shopping.CategoryId });
                }
            }
            catch (Exception)
            {

            }
            return View(shopping);
        }

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Product model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var product = _context.Products.Find(model.Id);
        //            _context.Products.Add(product);
        //            _context.SaveChanges();
        //            return RedirectToAction();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return View(model);
        

    }
}
