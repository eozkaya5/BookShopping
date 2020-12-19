using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using BookShopping.Models.ShoppingModel;
using Microsoft.AspNetCore.Mvc;

namespace BookShopping.Controllers
{
    public class ContactController : Controller
    {     
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587); 
                client.Credentials = new NetworkCredential("BookShopping12@gmail.com", "book5734");
                client.EnableSsl = true;
                MailMessage message = new MailMessage();
                message.From = new MailAddress(contact.EMail, contact.Name + " " + contact.SurName);
                message.To.Add("BookShopping12@gmail.com");
                message.Subject = contact.Subject + "" + contact.EMail;
                message.Body = contact.Message; 
                client.Send(message); 
               
                MailMessage message1 = new MailMessage();
                message1.From = new MailAddress("BookShopping12@gmail.com", "Book Shopping");
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
