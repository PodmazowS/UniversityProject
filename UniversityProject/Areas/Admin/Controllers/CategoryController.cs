﻿using Microsoft.AspNetCore.Mvc;

namespace UniversityProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
