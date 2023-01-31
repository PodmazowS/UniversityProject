using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.ViewModels
{
    public class CartVM
    {
        public List<Cart> ListOfCart { get; set; }
        public OrderHeader OrderHeader { get; set; }
    }
}
