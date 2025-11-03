using CustomClientValidation.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomClientValidation.Controllers
{
    public class ValidationController : Controller
    {
        private RegistrationContext _context;
        public ValidationController(RegistrationContext context)
        {
            _context = context;
        }

        public JsonResult CheckEmail(string EmailAddress)
        {
            if(_context.Customers.Any(c => c.EmailAddress == EmailAddress))
            {
                return Json("Email already exist.");
            }
            else
            {            //passes validation
                return Json(true);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
