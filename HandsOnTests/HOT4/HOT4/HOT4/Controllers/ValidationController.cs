using HOT4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT4.Controllers
{
    public class ValidationController : Controller
    {
        private AppointmentContext _context {  get; set; }
        public ValidationController(AppointmentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
