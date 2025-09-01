using Microsoft.AspNetCore.Mvc;
using Code_Along1.Models;

namespace Code_Along1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.FV = 0;
            return View();
        }
        [HttpPost]
        public IActionResult Index(FutureValueModel fv)
        {
            if(ModelState.IsValid)
            {
                ViewBag.FV = fv.CalculateFutureValue();

            }
            else
            {
                ViewBag.FV = 0;
            }
               
            return View(fv);
        }
    }
}
