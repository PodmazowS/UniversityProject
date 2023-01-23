using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.Models;
using System.Diagnostics;


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