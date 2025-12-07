using Microsoft.AspNetCore.Mvc;

namespace NovelNookBookStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
