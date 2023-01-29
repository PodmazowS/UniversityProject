using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Models;
using System.Diagnostics;
using ShoppingBasket.DataAccess.ViewModels;
using ShoppingBasket.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UniversityProject.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IAssignment _assignment;

        public HomeController(ILogger<HomeController> logger, IAssignment assignment)
        {
            _logger = logger;
            _assignment = assignment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> products = _assignment.Product.GetAll(includeProperties: "Category");
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int? productId)
        {
            Cart shoppingBasket = new Cart()
            {
                Product = _assignment.Product.GetT(x=>x.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = (int)productId
            };
            return View(shoppingBasket);
        }
        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public IActionResult Details(Cart cart)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var claimsIdentity = (ClaimsIdentity)User.Identity;
        //        var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //        cart.AppUserId = claims.Value;

        //        var cartItem = _assignment.Cart.GetT(x => x.ProductId == cart.ProductId &&
        //        x.AppUserId == claims.Value);
        //        if (cartItem == null) {
        //            _assignment.Cart.Add(cart);
        //            _assignment.Save();
        //            HttpContext.Session.SetInt32("SessionCart", _assignment
        //                .Cart.GetAll(x => x.AppUserId == claims.Value).ToList().Count);
        //        }
        //        else
        //        {
        //            _assignment.Cart.IncrementCartItem(cartItem, cart.Count);
        //            _assignment.Save();
        //        }
                
        //    }
        //    return RedirectToAction("Index");
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}