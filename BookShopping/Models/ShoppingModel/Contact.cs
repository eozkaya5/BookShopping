using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopping.Models.ShoppingModel
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string EMail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }

        public string UserId { get; set; }
    }
}
