using Microsoft.AspNetCore.Mvc;

namespace Code_Along1.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.Name = "Cami Carstens";
            ViewBag.Salary = 60000;
            return View();
        }
    }
}
