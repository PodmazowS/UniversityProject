using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.Models;

namespace UniversityProject.Web.Api
{
    [Route("api/ProductController")]
    [ApiController]
    public class ProductControllerApi : ControllerBase
    {
        private IAssignment _assignment;
        private IWebHostEnvironment _environment;

        public ProductControllerApi(IAssignment assignment, IWebHostEnvironment environment)
        {
            _assignment = assignment;
            _environment = environment;
        }
        [HttpGet]
        IActionResult AllProducts()
        {
            var products = _assignment.Product.GetAll(includeProperties: "Category");
            return Ok(new { data = products });
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _assignment.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _assignment.Product.Add(product);
                _assignment.Save();
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _assignment.Product.Update(product);
                _assignment.Save();
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _assignment.Product.GetT(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _assignment.Product.Delete(product);
            _assignment.Save();
            return NoContent();
        }
    }
}