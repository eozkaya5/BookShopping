using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookShopping.Models.Authentication;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using BookShopping.Repository;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


namespace BookShopping.Controllers
{

    public class ProductController : Controller
    {

        #region Ürün; ekle,sil düzenle listele

        readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        readonly IWebHostEnvironment _environment;
        public readonly ShoppingDbContext _context;

        public ProductController(ShoppingDbContext context, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        public IActionResult Detail(int id)
        {
            ViewBag.UserName = User.Identity.Name;
            List<Product> model = _context.Products.Where(x => x.Id == id).ToList();
            ViewBag.CategoryId = id;
            return View(model);
        }     

        public IActionResult Index(int id)
        {
            ViewBag.UserName = User.Identity.Name;
            List<Product> model = _context.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            ViewBag.CategoryId = id;
            return View(model);
        }

        public IActionResult List(int id)
        {
            ViewBag.UserName = User.Identity.Name;
            List<Product> model = _context.Products.Include(x => x.Category).Where(x => x.CategoryId == id).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.UserName = User.Identity.Name;
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

                    if (shopping.PictureFolder != null)
                    {
                        string folder = "pictures/";
                        folder += Guid.NewGuid().ToString() + "_" + shopping.PictureFolder.FileName;
                        shopping.PictureWay = "/" + folder;
                        string serverFolder = Path.Combine(_environment.WebRootPath, folder);
                        shopping.PictureFolder.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    }
                    _context.Products.Add(shopping);
                    TempData["Create"] = shopping.Name + "  " + " ürün eklendi.";
                    _context.SaveChanges();
                    return RedirectToAction("Index",new { id = shopping.CategoryId });
                }
            }
            catch (Exception)
            {
            }
            return View(shopping);
        }

        public IActionResult Delete(int id)
        {
            var delete = _context.Products.Find(id);
            _context.Products.Remove(delete);
            TempData["delete"] = delete.Name + "  " + "ürünü silindi.";

            _context.SaveChanges();
            return RedirectToAction("Index", new { id = delete.CategoryId });
        }

        public IActionResult Select(string search)
        {
            var model = _context.Products.ToList();
            if (!string.IsNullOrEmpty(search))
            {
                model = model.Where(x => x.Name.Contains(search)).ToList();
            }
            return RedirectToAction("HomeProduct", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.UserName = User.Identity.Name;
            var model = _context.Products.FirstOrDefault(x => x.Id == id); 
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Product product, int id)
        {
            try
            {
                if (product.PictureFolder != null)
                {
                    string folder = "pictures/";
                    folder += Guid.NewGuid().ToString() + "_" + product.PictureFolder.FileName;
                    product.PictureWay = "/" + folder;
                    string serverFolder = Path.Combine(_environment.WebRootPath, folder);
                    product.PictureFolder.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }
                if (ModelState.IsValid)
                {
                    var model = _context.Products.FirstOrDefault(x => x.Id == id);
                    model.Name = product.Name;
                    model.Comment = product.Comment;
                    model.Quantity = product.Quantity;
                    model.PictureWay = product.PictureWay;
                   
                    _context.SaveChanges();
                    return RedirectToAction("Index", new { id = model.CategoryId });
                }
            }
            catch (Exception)
            {

                
            }
            return View(product);
        }

        //public IActionResult Status(int id)
        //{
        //    var product = _context.Products.Find(id);
        //    product.Status = !product.Status;
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", new { id = product.CategoryId });
        ////}
        #endregion

    }
}

