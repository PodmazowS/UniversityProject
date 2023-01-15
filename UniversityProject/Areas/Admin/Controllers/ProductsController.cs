using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.DataAccess.ViewModels;
using ShoppingBasket.DataAccess.Data;
using ShoppingBasket.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UniversityProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private IAssignment _assignment;
        private IWebHostEnvironment _environment;

        public ProductsController(IAssignment assignment, IWebHostEnvironment environment)
        {
            _assignment = assignment;
            _environment = environment;
        }
        #region APICALL
        public IActionResult AllProducts()
        {
            var products = _assignment.Product.GetAll(includeProperties: "Category");
            return Json(new { data = products });

        }
        #endregion

        public IActionResult Index() {
            return View();
        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {

            ProductViewModel pvm = new ProductViewModel()
            {
                Product = new Product(),

                Categories = _assignment.Category.GetAll().Select(x => new SelectListItem
                { Text = x.Name,
                  Value = x.Id.ToString() 
                })
            };
            if (id == null || id == 0)
            {
                return View(pvm);
            }
            else
            {
                pvm.Product = _assignment.Product.GetT(x => x.Id == id);
                if (pvm.Product == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(pvm);
                }
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdate(ProductViewModel pvm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string fileName = String.Empty;
                if (file != null)
                {
                    string uploadDir = Path.Combine(_environment.WebRootPath, "ProductImage");
                    fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
                if (pvm.Product.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, pvm.Product.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }
                pvm.Product.ImageUrl = @"\ProductImage\" + fileName;
            }
            if (pvm.Product.Id == 0)
            {
                _assignment.Product.Add(pvm.Product);
                TempData["success"] = "Product Created Done!";

            }
            else
            {
                _assignment.Product.Update(pvm.Product);
                TempData["success"] = "Product Update Done!";
            }
            _assignment.Save();
            return RedirectToAction("Index");
        }
        #region DeleteAPICALL
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var product = _assignment.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return Json(new { success = false, message = "Error in Fetching Data" });
            }
            else
            {
                var oldImagePath = Path.Combine(_environment.WebRootPath, product.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);

                }
                _assignment.Product.Delete(product);
                _assignment.Save();
                return Json(new { success = true, message = "Product Deleted" });
            }
        }
        #endregion
    }
}
