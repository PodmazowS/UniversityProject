using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ShoppingBasket.DataAccess.ViewModels
{
    public class ProductViewModel
    {

        public Product Product { get; set; } = new Product();
        [ValidateNever]
        public IEnumerable<Product> Products { get; set;} 
            = new List<Product>();
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }


    }
}
