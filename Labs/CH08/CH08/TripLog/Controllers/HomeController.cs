using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly TripContext _context;
        public HomeController(TripContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Trip Log";
            ViewBag.SubHeader = "";
            var trips = _context.Trips.ToList();
            return View(trips);
        }

       
    }
}
