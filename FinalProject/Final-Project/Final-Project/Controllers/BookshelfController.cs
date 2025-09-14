using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class BookshelfController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
