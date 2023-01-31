using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBasket.DataAccess.Data;
using ShoppingBasket.Models;

namespace ShoppingBasket.DataAccess.Repositories
{
    public class ApplicationUserRepository : ApplicationUser
    {
        private ApplicationDbContext _context;

        public ApplicationUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetById(int id)
        {
            return _context.ApplicationUser.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}