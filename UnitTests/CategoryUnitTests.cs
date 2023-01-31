using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.DataAccess.Repositories;
using ShoppingBasket.DataAccess.ViewModels;
using ShoppingBasket.Models;
using System;
using UniversityProject.Web.Areas.Admin.Controllers;
using Xunit;

namespace UnitTests
{
    public class CategoryControllerTests
    {
        private readonly IAssignment _assignment;
        private readonly CategoryController _controller;

        public CategoryControllerTests()
        {

            _controller = new CategoryController(_assignment);
        }


        [Fact]
        public void Delete_ReturnsNotFoundResult_WhenIdIsNull()
        {
            // Act
            var result = _controller.Delete(null);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }

}