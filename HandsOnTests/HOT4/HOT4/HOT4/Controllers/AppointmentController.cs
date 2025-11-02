using HOT4.Models;
using HOT4.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOT4.Controllers
{
    public class AppointmentController : Controller
    {
        private AppointmentContext _context;
        public AppointmentController(AppointmentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Appointment app)
        {
            //var appConflict = _context.Appointments.Any(a =>
            //a.AppDate.Date == app.AppDate.Date &&
            //a.AppTime == app.AppTime &&
            //a.AppointmentId != app.AppointmentId);

            //if (appConflict)
            //{
            //    ModelState.AddModelError("", "That appointment slot is already booked. ");
            //}

            if (ModelState.IsValid)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Username == app.Username);

                if (customer == null)
                {
                    customer = new Customer
                    {
                        Username = app.Username,
                        PhoneNumber = app.PhoneNumber
                    };
                    _context.Customers.Add(customer);
                    _context.SaveChanges(); // Save to get CustomerId
                }

                app.CustomerId = customer.CustomerId;

                _context.Appointments.Add(app);
                _context.SaveChanges();

                TempData["message"] = "Appointment Added";
                return RedirectToAction("Index", "Home");
            }

            return View(app);
        }

        
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var appointments = _context.Appointments
        //        .Include(a => a.Username)
        //        .OrderBy(a => a.AppDate)
        //        .ThenBy(a => a.AppTime)
        //        .ToList();

        //    return View(appointments);
        //}
    }
}
