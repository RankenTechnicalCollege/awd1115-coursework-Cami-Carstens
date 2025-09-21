using Microsoft.AspNetCore.Mvc;

namespace NovelNook.Controllers
{
    public class BookshelfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
