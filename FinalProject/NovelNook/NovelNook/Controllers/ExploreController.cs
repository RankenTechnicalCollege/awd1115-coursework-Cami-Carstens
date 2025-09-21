using Microsoft.AspNetCore.Mvc;

namespace NovelNook.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
