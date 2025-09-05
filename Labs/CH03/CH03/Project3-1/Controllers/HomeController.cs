using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project3_1.Models;

namespace Project3_1.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CalculateQuote();
            model.Subtotal= 0;
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CalculateQuote model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            return View(model);
        }

        }
}
