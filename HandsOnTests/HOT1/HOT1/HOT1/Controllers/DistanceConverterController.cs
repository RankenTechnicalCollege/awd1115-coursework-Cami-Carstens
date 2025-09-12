using Microsoft.AspNetCore.Mvc;
using HOT1.Models;

namespace HOT1.Controllers
{
    public class DistanceConverterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Converter c = new Converter();
            c.Inches = 0;
            return View(c);
        }

        [HttpPost]
        public IActionResult Index(Converter c)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Message = c.ToString();
            }
            return View(c);
        }
    }
}
