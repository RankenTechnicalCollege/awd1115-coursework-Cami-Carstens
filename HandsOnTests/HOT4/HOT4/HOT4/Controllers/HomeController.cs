using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace HOT4.Controllers
{
    public class HomeController : Controller
    {
        private AppointmentContext _context;
        public HomeController(AppointmentContext context)
        {
            _context = context;
        }

        public IActionResult Index() { return View(); }

        [HttpGet]
        public IActionResult Privacy()
        {
            var vm = new AppointmentListViewModel
            {
                Appointments = _context.Appointments
                    .Include(a => a.Customer) 
                    .OrderBy(a => a.AppDate)
                    .ThenBy(a => a.AppTime)
                    .ToList()
            };

            return View(vm); 
        }



    }
}
