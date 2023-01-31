using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.DataAccess.ViewModels;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Web.Areas.Admin.Controllers;
using Assert = Xunit.Assert;

namespace UnitTests
{
    [TestClass]
    public class CreateUpdateTests
    {
        private readonly IAssignment _assignment = Substitute.For<IAssignment>();
        private readonly ProductsController _controller;

        //public CreateUpdateTests()
        //{
        //    _controller = new ProductsController(_assignment);
        //}

        [Fact]
        public void CreateUpdate_WithId_ReturnsViewResult()
        {
            // Arrange
            int id = 1;
            Product product = new Product { Id = id };
            _assignment.Product.GetT(x => x.Id == id).Returns(product);

            // Act
            var result = _controller.CreateUpdate(id);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.IsType<ProductViewModel>(viewResult.Model);
            var pvm = (ProductViewModel)viewResult.Model;
            Assert.Equal(product, pvm.Product);
        }

        [Fact]
        public void CreateUpdate_WithId_ReturnsNotFound()
        {
            // Arrange
            int id = 1;
            _assignment.Product.GetT(x => x.Id == id).Returns((Product)null);

            // Act
            var result = _controller.CreateUpdate(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateUpdate_WithoutId_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.CreateUpdate(null);

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.IsType<ProductViewModel>(viewResult.Model);
            var pvm = (ProductViewModel)viewResult.Model;
            Assert.NotNull(pvm.Product);
        }
    }
}
