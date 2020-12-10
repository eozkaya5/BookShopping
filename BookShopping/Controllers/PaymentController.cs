using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookShopping.Models.Context;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class PaymentController : Controller
    {
        readonly ShoppingDbContext _context;
        public PaymentController(ShoppingDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id,decimal totalPay)
        {            
            List<Payment> model = _context.Payments.Where(x => x.BasketId == id).ToList();
            if (model != null )
            {
                totalPay = _context.Payments.Sum(x => x.TotalFee);
                ViewBag.totalPay = +totalPay + "₺";
            }           
            ViewBag.BasketId = id;
            return View(model);
        }
        [HttpGet]
        public IActionResult Pay(int id)
        {
            var model = new Payment { BasketId = id };
            return View(model);
        }
        [HttpPost]
        public IActionResult Pay(Payment model)
        {
            try
            {
                if (ModelState.IsValid)
                {                
                    var payment = _context.Baskets.Find(model.BasketId);
                    payment.TotalFee -= model.TotalFee;
                    model.Date = DateTime.Now;
                    _context.Payments.Add(model);
                    _context.SaveChanges();
                    return RedirectToAction("Index","Basket", new { id = model.BasketId });
                }
            }
            catch (Exception)
            {

            }
            return View(model);
        }


    }

}

