﻿using Microsoft.AspNetCore.Mvc;
using ValidationCodeAlong.Models;

namespace ValidationCodeAlong.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Add(Customer c)
        {
            if (ModelState.IsValid)
            {
                return Content("Customer added successfully");
            }
            else
            {
                return View(c);
            }
        }
    }
}
