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
using Microsoft.CodeAnalysis;

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
           
           
         var  model = _context.UserComments.Where(x => x.ProductId == id).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            return View(_context.Products.Find(id));

        }
        [HttpPost]
        public IActionResult Create(UserComment userComment, int id)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = User.Identity.Name;
            //    var model = _userManager.Users.FirstOrDefault(x => x.UserName == user);
               // var payment = _context.Payments.Find(id);


                var comment = _context.UserComments.Find(id);
                //var add = new UserComment
                //{
                //    UserId = model.Id,
                //    PaymentId = payment.Id,
                //    ProductId=product.Id,
                //    UserName = model.UserName,
                //    Email = model.Email,
                //    Date = DateTime.Now



                //};      

                _context.UserComments.Add(comment);
                TempData["create"] = "Yorum" + " " + comment.Comment + "" + " eklendi.";
                _context.SaveChanges();
            
            return View(userComment);
        }

    }
}

