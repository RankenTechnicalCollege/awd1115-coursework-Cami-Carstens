using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Areas.Help.Controllers
{
    [Area("Help")]
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            ViewBag.ActiveTab = "Home";
            return View();
        }

       
    }
}
