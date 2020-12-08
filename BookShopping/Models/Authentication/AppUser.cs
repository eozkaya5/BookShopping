using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.Authentication 
{
    public class AppUser:IdentityUser<int>
    {
       

        //[Required(ErrorMessage = "LÜtfen şifreyi boş geçmeyiniz..")]
        //[DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        //[Display(Name = "Password")]
       

        //public DateTime Date { get; set; }
        //public string Address { get; set; }
    }
}