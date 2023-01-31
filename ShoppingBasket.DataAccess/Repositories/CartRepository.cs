using ShoppingBasket.DataAccess.Data;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Cart cart)
        {
            _context.Cart.Add(cart);
        }

        public void Delete(Cart cart)
        {
            _context.Cart.Remove(cart);
        }

        public void IncrementCartItem(Cart cart, int count)
        {
            cart.Count += count;
        }

        public void DecrementCartItem(Cart cart, int count)
        {
            cart.Count -= count;
        }

        public IEnumerable<Cart> GetAll(Func<Cart, bool> predicate, string includeProperties = "")
        {
            var query = _context.Cart.AsQueryable();
            if (predicate != null)
            {
                query = (IQueryable<Cart>)query.Where(predicate);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.ToList();
        }

        public Cart GetT(Func<Cart, bool> predicate, string includeProperties = "")
        {
            var query = _context.Cart.AsQueryable();
            if (predicate != null)
            {
                query = (IQueryable<Cart>)query.Where(predicate);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }
    }
}
