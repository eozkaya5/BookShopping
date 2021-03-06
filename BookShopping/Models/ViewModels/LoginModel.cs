﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ViewModel
{
    public class LoginModel 
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresini boş geçmeyiniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta e-posta adresi giriniz.")]
        [Display(Name = "E-Posta ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "LÜtfen şifreyi boş geçmeyiniz..")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string Adress { get; set; }
        [Display(Name = "Beni Hatırla")]
        public string PhoneNumber { get; set; }
        public bool Persistent { get; set; }
        public bool Lock { get; set; }
    }
}
