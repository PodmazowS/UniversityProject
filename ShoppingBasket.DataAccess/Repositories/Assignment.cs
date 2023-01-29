using ShoppingBasket.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public class Assignment : IAssignment
    {
        private ApplicationDbContext _context;
        public ICategoryR Category { get; private set; }
        public IProductR Product { get; private set; }
        public Assignment(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryR(context);
            Product = new ProductR(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
