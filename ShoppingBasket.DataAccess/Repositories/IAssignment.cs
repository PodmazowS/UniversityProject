using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    internal interface IAssignment
    {
        IProductR Product { get; }
        ICategoryR Category { get; }
        void Save();
    }
}
