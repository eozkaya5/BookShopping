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
            model.Comment = _context.UserComments.Where(x => x.ProductId == id).ToList();

            return View(model);
        }

        public IActionResult Create(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                var model = _userManager.Users.FirstOrDefault(x => x.UserName == user);
                var payment = _context.Payments.Find(id);
                var product = _context.Products.Find(id);

                var comment = _context.UserComments.FirstOrDefault(x => x.UserId == model.Id && x.PaymentId == payment.Id);
                var add = new UserComment
                {
                    UserId = model.Id,
                    PaymentId = payment.Id,
                    ProductId=product.Id,
                    UserName = model.UserName,
                    Email = model.Email,
                    Comment = comment.Comment,
                    Date = DateTime.Now



                };            
                _context.UserComments.Add(add);
                TempData["create"] = "Yorum" + " " + comment.Comment + "" + " eklendi.";
                _context.SaveChanges();              
            }
            return RedirectToAction("Index");
        }

    }
    }
