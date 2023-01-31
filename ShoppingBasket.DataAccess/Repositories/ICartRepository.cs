using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public interface ICartRepository
    {
        void Add(Cart cart);
        void Delete(Cart cart);
        void IncrementCartItem(Cart cart, int count);
        void DecrementCartItem(Cart cart, int count);
        IEnumerable<Cart> GetAll(Func<Cart, bool> predicate, string includeProperties = "");
        Cart GetT(Func<Cart, bool> predicate, string includeProperties = "");
    }
}
