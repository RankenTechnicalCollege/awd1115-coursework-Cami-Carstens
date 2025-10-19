using Microsoft.AspNetCore.Mvc;
using Ch09_Sessions.Models;

namespace Ch09_Sessions.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            HttpContext.Session.SetObject("currentUser", u);
            return RedirectToAction("Index", "Home");
        }
    }
}
