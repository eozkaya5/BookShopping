﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BookShopping.Models.Authentication;
using BookShopping.Models.Context;
using BookShopping.Models.ViewModel;
using BookShopping.Poco;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace BookShopping.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IConfiguration _configuration;
        readonly LoginDbContext _context=null;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        public SecurityController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, LoginDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _configuration = configuration;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    Name = user.Name,
                    SurName = user.SurName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Adress = user.Adress,
                    PhoneNumber= user.PhoneNumber

                };
                IdentityResult pasword = await _userManager.CreateAsync(appUser, user.Password);
                if (pasword.Succeeded)
                    return RedirectToAction("Index", "Security");
                else
                    pasword.Errors.ToList().ForEach(x => ModelState.AddModelError(x.Code, x.Description));                

            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await _userManager.FindByEmailAsync(login.Email);
                if (appUser != null)
                {
                    await _signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, login.Password, login.Persistent, login.Lock);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Home");
                    ModelState.AddModelError("NotUser2", "E-Posta veya şifre hatalı.");
                }
                else
                {
                    ModelState.AddModelError("NotUser", "Böyle bir kullanıcı bulunmamaktadır.");
                }
            }
            return View("Index");
        }
        
        [HttpGet]
        public IActionResult PasswordReset()
        {         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(ResetPasswordModel reset)
        {
          
            AppUser user = await _userManager.FindByEmailAsync(reset.Email);
            if (user != null)
            {
                var email = _configuration["MyConfig:Email"];
                var password = _configuration["MyConfig:Password"];
                var host = _configuration["MyConfig:Host"];

                string token = await _userManager.GeneratePasswordResetTokenAsync(user);
               
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.To.Add(user.Email);
                mail.From = new MailAddress(email, "Şifre Güncelleme", System.Text.Encoding.UTF8);
                mail.Subject = "Şifre Güncelleme Talebi";
                mail.Body = $"<a target=\"_blank\" href=\"https://localhost:44370{Url.Action("EditPassword", "Security", new { Id = user.Id, token = HttpUtility.UrlEncode(token) })}\">Yeni şifre talebi için tıklayınız</a>";
                mail.IsBodyHtml = true;

                SmtpClient smp = new SmtpClient();
                smp.Credentials = new NetworkCredential(email, password);
                smp.Port = 587;
                smp.Host = host;
                smp.EnableSsl = true;
                smp.Send(mail);

                ViewBag.State = true;
            }
            else
                ViewBag.State = false;

            return View();
        }

        [HttpGet("[action]/{Id}/{token}")]
        public IActionResult EditPassword(string Id, string token)
        {
            return View();
        }
        [HttpPost("[action]/{Id}/{token}")]
        public async Task<IActionResult> EditPassword(AppUser update, string Id, string token)
        {
            AppUser user = await _userManager.FindByIdAsync(Id);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(token), update.NewPassword);
            if (result.Succeeded)
            {
                ViewBag.State = true;
                await _userManager.UpdateSecurityStampAsync(user);
                return RedirectToAction("Index", "Security");
            }
            else
                ViewBag.State = false;
            return View();
        }
     
        [HttpGet]
        public IActionResult EditProfile(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(AppUser model,int id)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Id == id);
                user.PhoneNumber = model.PhoneNumber;
                user.Adress = model.Adress;
                user.Name = model.Name;
                user.SurName = model.SurName;
             
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    result.Errors.ToList().ForEach(e => ModelState.AddModelError(e.Code, e.Description));
                    return View(model);
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(user, true);
            }
            return RedirectToAction("Information",new { id=model.Id} );
        }
        // [Route("Security/Information/{id}")]
        public IActionResult Information(int id)
        {
            ViewBag.UserName = User.Identity.Name;
            List<AppUser> model = _userManager.Users.Where(x => x.Id == id).ToList();
            ViewBag.Id = id;
            return View(model);
        }

        //[Authorize(Roles = "eozkaya675@gmail.com")]
        public IActionResult List()
        {
            ViewBag.UserName = User.Identity.Name;
            return View(_userManager.Users);
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(x=>x.Id==id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return View("List",_userManager.Users);
        }


        public IActionResult Account(int id)
        {
            ViewBag.UserName = User.Identity.Name;
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;

            List<AppUser> model = _userManager.Users.Where(x => x.Id == user.Id).ToList();

            return View(model);
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Security");
        }
        //private string GenerateJSONWebToken(UserModel userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["MyConfig:Password"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var _claims = new[] {
        //        new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //    };

        //    var token = new JwtSecurityToken(
        //      _configuration["Jwt:Issuer"],
        //      _configuration["Jwt:Issuer"],
        //      claims: _claims,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}


    }
}
   
