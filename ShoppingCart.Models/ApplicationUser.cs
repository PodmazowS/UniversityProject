using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Models
{
    [NotMapped]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string? Adress { get; set; }

        [MaxLength(50)]
        public string? City { get; set; }

        [MaxLength(10)]
        public string? PostalCode { get; set; }
    }
}
