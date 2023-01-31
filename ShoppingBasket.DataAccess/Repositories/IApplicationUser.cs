using ShoppingBasket.DataAccess.Data;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public interface IApplicationUser
    {
        ApplicationUser GetT(Func<ApplicationUser, bool> id);
        Task<List<ApplicationUser>> GetAll();
        void Add(ApplicationUser user);
        void Update(ApplicationUser user);
        void Remove(ApplicationUser user);
        
    }
}