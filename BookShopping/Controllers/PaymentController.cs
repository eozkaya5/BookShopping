using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookShopping.Models.Authentication;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class PaymentController : Controller
    {
        readonly ShoppingDbContext _context;
        readonly UserManager<AppUser> _userManager;
        public PaymentController(ShoppingDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index(int id, decimal totalPay,decimal totalQuantity)
        {
            ViewBag.UserName = User.Identity.Name;
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var basket = _context.Baskets.Find(id);
            List<Payment> model = _context.Payments.Where(x => x.UserId == user.Id).ToList();
            if (user != null)
            {                         
                totalPay = _context.Payments.Sum(x => x.TotalFee);
                totalQuantity = _context.Payments.Sum(x=>x.Quantity);
                ViewBag.totalPay = +totalPay + "₺";
                ViewBag.totalQuantity = +totalQuantity ;

            }
            ViewBag.BasketId = id;
            return View(model);
        }
        public IActionResult Pay(int id)
        {
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userName = User.Identity.Name;
                    var model = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
                    var basket = _context.Baskets.Find(id);
                   
                    var pay = _context.Payments.FirstOrDefault(x => x.UserId == model.Id && x.BasketId == id);
                    if (model != null)
                    {
                        var addBasket = new Payment
                        {
                            UserId = model.Id,
                            BasketId = basket.Id,
                            ProductId = basket.ProductId,
                            Name=basket.Name,
                            Quantity = basket.Quantity,
                            TotalFee = basket.TotalFee,
                            Date = DateTime.Now
                        };
                        _context.Payments.Add(addBasket);
                        TempData["message"] = "Seçtiğiniz " + addBasket.Name + " ismindeki  ürün satın alınmıştır.";
                        _context.SaveChanges();
                    }
                }
                    return RedirectToAction("Index");
            }
        }
        public IActionResult Delete(int id)
        {
            var pay = _context.Payments.Find(id);
            _context.Payments.Remove(pay);
            TempData["delete"] = "Seçtiğiniz  "+  pay.Name+" " +"ismindeki ürün silinmiştir." ;
            _context.SaveChanges();
            return RedirectToAction("Index", new { id = pay.BasketId });
        }
    }
}

