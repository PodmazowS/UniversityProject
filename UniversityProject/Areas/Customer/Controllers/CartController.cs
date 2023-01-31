using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.DataAccess.ViewModels;
using ShoppingBasket.Models;
using System.Security.Claims;

namespace UniversityProject.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private IAssignment _assignment;
        public CartVM cartVM { get; set; }
        public CartController(IAssignment assignment)
        {
            _assignment = assignment;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            cartVM = new CartVM()
            {
                ListOfCart = (List<Cart>)_assignment.Cart.GetAll(x => x.ApplicationUserId == claims.Value, includeProperties: "Product"),
                OrderHeader = new OrderHeader()
            };
            foreach (var item in cartVM.ListOfCart)
            {
                cartVM.OrderHeader.OrderTotal += (item.Product.Price * item.Count);
            }
            return View(cartVM);
        }
        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            cartVM = new CartVM()
            {
                ListOfCart = (List<Cart>)_assignment.Cart.GetAll(x => x.ApplicationUserId == claims.Value),
                OrderHeader = new OrderHeader()
            };
            cartVM.OrderHeader.ApplicationUser = _assignment.ApplicationUser.GetT(x => x.Id == claims.Value);
            cartVM.OrderHeader.Name = cartVM.OrderHeader.ApplicationUser.Name;
            cartVM.OrderHeader.PhoneNumber = cartVM.OrderHeader.ApplicationUser.PhoneNumber;
            cartVM.OrderHeader.Adress = cartVM.OrderHeader.ApplicationUser.Adress;
            cartVM.OrderHeader.City = cartVM.OrderHeader.ApplicationUser.City;
            cartVM.OrderHeader.PostalCode = cartVM.OrderHeader.ApplicationUser.PostalCode;

            foreach (var item in cartVM.ListOfCart)
            {
                cartVM.OrderHeader.OrderTotal += (item.Product.Price * item.Count);
            }
            return View(cartVM);
        }
        [HttpPost]
        public IActionResult plus(int id)
        {
            var cart = _assignment.Cart.GetT(x => x.Id == id);
            _assignment.Cart.IncrementCartItem(cart, 1);
            _assignment.Save();
            return RedirectToAction("Index");
        }
        public IActionResult minus(int id)
        {
            var cart = _assignment.Cart.GetT(x => x.Id == id);
            if (cart.Count <= 1)
            {
                _assignment.Cart.Delete(cart);

            }
            else
            {
                _assignment.Cart.DecrementCartItem(cart, 1);
            }
            _assignment.Save();
            return RedirectToAction("Index");
        }
        public IActionResult delete(int id)
        {
            var cart = _assignment.Cart.GetT(x => x.Id == id);
            _assignment.Cart.Delete(cart);
            _assignment.Save();
            return RedirectToAction("Index");
        }

    }
}
