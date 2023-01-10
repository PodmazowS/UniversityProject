using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.DataAccess.ViewModels;

namespace UniversityProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IAssignment _assignment;

        public CategoryController(IAssignment assignment)
        {
            _assignment = assignment;

        }

        public IActionResult Index()
        {
            CategoryViewModels categoryVM = new CategoryViewModels();
            categoryVM.categories = _assignment.Category.GetAll();
            return View(categoryVM);
        }
    }
}
