using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShopping.Models.Authentication;
using BookShopping.Models.Context;
using BookShopping.Models.ModelTypes;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class CommentController : Controller
    {
        readonly UserManager<AppUser> _userManager;
        readonly ShoppingDbContext _context;
        public CommentController(ShoppingDbContext context, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int id)
        {
            ViewModel model = new ViewModel();
            model.HomePage = _context.Products.ToList();
            model.SideBar = _context.Categories.ToList();
            model.Comment = _context.UserComments.Where(x=>x.ProductId==id).ToList();
           
            return View(model);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {    
            ViewBag.ProductId = id;

           var product = new UserComment {  ProductId=id };
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(UserComment model)
        {

              var comment = _context.UserComments.Find(model.ProductId);
            //model.Id = comment.ProductId;
            _context.UserComments.Add(model);
                TempData["create"] = "Yorum" + " " + model.Comment + "" + " eklendi.";
                _context.SaveChanges();

                return View(model);
           
        }
    }
}
