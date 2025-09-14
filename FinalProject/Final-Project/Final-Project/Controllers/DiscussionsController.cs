using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
    public class DiscussionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
