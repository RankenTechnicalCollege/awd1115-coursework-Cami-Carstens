using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
