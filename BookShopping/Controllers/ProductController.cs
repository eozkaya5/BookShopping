using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookShopping.Controllers
{

    public class ProductController : Controller
    {
        public readonly ShoppingDbContext _context;
        public ProductController(ShoppingDbContext context)
        {
            _context = context;
        }
        public IActionResult Detail(int id)
        {
            List<Product> model = _context.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            ViewBag.CategoryId = id;
            return View(model);
        }

        public IActionResult Index(int id)
        {
            List<Product> model = _context.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            ViewBag.CategoryId = id;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            var product = new Product { CategoryId = id };
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product shopping)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = _context.Categories.Find(shopping.CategoryId);
                    _context.Products.Add(shopping);
                    _context.SaveChanges();
                    return RedirectToAction("Index", new { id = shopping.CategoryId });
                }
            }
            catch (Exception)
            {
            }
            return View(shopping);


            //if (shopping != null)
            //{
            //    string name = System.IO.Path.GetFileName(shopping.Picture);
            //    string yol = "~/Images/" + name;

            //}


            // if (file != null)
            //    {
            //        string imageExtension = Path.GetExtension(file.Name);

            //string imageName = Guid.NewGuid() + imageExtension;

            //string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");

            //        using var stream = new FileStream(path, FileMode.Create);


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var edit = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(edit);
        }
        [HttpPost]
        public IActionResult Edit(Product product, int id)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var edit = _context.Products.FirstOrDefault(x=>x.Id==id);
                    edit.Name = product.Name;
                    edit.Price = product.Price;
                    edit.Comment = product.Comment;
                    _context.SaveChanges();
                    return RedirectToAction("İndex", new { id = edit.CategoryId });

                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(product);
        }
        public IActionResult Delete(int id)
        {
            var delete = _context.Products.Find(id);
            _context.Products.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = delete.CategoryId });
        }
    }


}

