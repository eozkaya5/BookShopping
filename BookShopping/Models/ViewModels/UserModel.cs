using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ViewModel 
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "LÜtfen adı boş geçmeyiniz..")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LÜtfen soyadı boş geçmeyiniz..")]
        public string SurName { get; set; }
        [Required(ErrorMessage = "LÜtfen kullanıcı adını boş geçmeyiniz..")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen e-posta adresini boş geçmeyiniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta e-posta adresi giriniz.")]
        [Display(Name = "E-Posta ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "LÜtfen şifreyi boş geçmeyiniz..")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "LÜtfen adresi boş geçmeyiniz..")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "LÜtfen telefon numarasını boş geçmeyiniz..")]
        public string PhoneNumber { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public bool Persistent { get; set; }
      


    }
}
