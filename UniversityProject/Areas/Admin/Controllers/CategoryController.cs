using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.DataAccess.ViewModels;

namespace UniversityProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

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
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryViewModels vm = new CategoryViewModels();
            if (id == null || id == 0) {
                return View(vm);
            }
            else
            {
                vm.Category = _assignment.Category.GetT(x => x.Id == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(CategoryViewModels vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.Category.Id == 0) {
                    _assignment.Category.Add(vm.Category);
                    TempData["success"] = "Category Created";
                }
                else {
                    _assignment.Category.Update(vm.Category);
                    TempData["success"] = "Category Updated";
                }
                _assignment.Save();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _assignment.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteData(int? id) {
            var category = _assignment.Category.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _assignment.Category.Delete(category);
            _assignment.Save();
            TempData["success"] = "Category Deleted";
            return RedirectToAction("Index");
        }
    }
}
