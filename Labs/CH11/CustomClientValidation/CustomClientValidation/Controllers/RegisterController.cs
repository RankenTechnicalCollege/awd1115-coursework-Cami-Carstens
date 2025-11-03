using CustomClientValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomClientValidation.Controllers
{
    public class RegisterController : Controller
    {
        private RegistrationContext _context;
        public RegisterController(RegistrationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(customer);
            }
        }
    }
}
