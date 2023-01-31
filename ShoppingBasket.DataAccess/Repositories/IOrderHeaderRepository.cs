using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public interface IOrderHeaderRepository
    {
        int Id { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
        string Adress { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        double OrderTotal { get; set; }
        ApplicationUser ApplicationUser { get; set; }
        //ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
