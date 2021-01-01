using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookShopping.Controllers
{
   
    public class ContactController : Controller
    {
        readonly IConfiguration _configuration;
        public ContactController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    
            [HttpGet]
        public IActionResult Index()
        {
           ViewBag.UserName= User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            try
            {
                var email = _configuration["MyConfig:Email"];
                var password = _configuration["MyConfig:Password"];
                var host = _configuration["MyConfig:Host"];
             
                SmtpClient client = new SmtpClient(host, 587); 
                client.Credentials = new NetworkCredential(email, password);
                client.EnableSsl = true;
                MailMessage message = new MailMessage();
                message.From = new MailAddress(contact.EMail, contact.Name + " " + contact.SurName);
                message.To.Add(email);
                message.Subject = contact.Subject + "" + contact.EMail;
                message.Body = contact.Message; 
                client.Send(message); 
               
                MailMessage message1 = new MailMessage();
                message1.From = new MailAddress(email, "Book Shopping");
                message1.To.Add(contact.EMail);
                message1.Subject = "Mail'inize Cevap";
                message1.Body = "Size En kısa sürede döneceğiz. Bizi tercih ettiğiniz için, teşekkür ederiz.";
                client.Send(message1);
                ViewBag.Succes = "Teşekkürler. Mail'iniz başarılı bir şekilde gönderildi"; 
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Mesaj Gönderilirken hata olıuştu"; 
                return View();
            }
        }
    }
}
