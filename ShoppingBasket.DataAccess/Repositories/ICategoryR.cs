using Microsoft.EntityFrameworkCore.Update.Internal;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public interface ICategoryR : IRepository<Category>
    {
        void Update(Category category); 
    }
}
