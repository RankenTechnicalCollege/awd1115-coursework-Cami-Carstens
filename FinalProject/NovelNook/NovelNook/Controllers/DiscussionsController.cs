using Microsoft.AspNetCore.Mvc;

namespace NovelNook.Controllers
{
    public class DiscussionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
