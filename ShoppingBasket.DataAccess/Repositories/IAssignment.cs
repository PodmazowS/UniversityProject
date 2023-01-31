using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public interface IAssignment
    {
        IProductR Product { get; }
        ICategoryR Category { get; }
        ICartRepository Cart { get; }
        IApplicationUser ApplicationUser { get; }

        void Save();
    }
}
