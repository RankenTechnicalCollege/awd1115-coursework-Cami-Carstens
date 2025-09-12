using Microsoft.AspNetCore.Mvc;
using HOT1.Models;

namespace HOT1.Controllers
{
    public class TshirtController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Tshirt tshirt = new Tshirt()
            {
                Price = 15,
                SalesTax = 0.08m
            };
           

            return View(tshirt);
        }
        [HttpPost]
        public IActionResult Index(Tshirt s)
        {
            s.Price = 15;
            s.SalesTax = 0.08m;

            //Check if discount code is valid
            if(!s.IsValidDiscountCode())
            {
                ModelState.AddModelError("DiscountCode", "Discount code is not valid.");
            }

            ViewBag.Message = s.ToString();
            return View(s);


            //this does not print the <p>  ViewBag.Message in the View bc the modelstate is not valid
            //if (ModelState.IsValid)
            //{
            //    ViewBag.Message = s.ToString();

            //    return View(s);
            //}
            //else
            //{
            //    return View(s);
            //}
        }
    }
}
