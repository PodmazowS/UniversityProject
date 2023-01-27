using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.ViewModels
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Adress { get; set; }
    }
}
