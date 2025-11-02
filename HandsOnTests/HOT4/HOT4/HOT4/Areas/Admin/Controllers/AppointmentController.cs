using HOT4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT4.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        private readonly AppointmentContext _context;
        public AppointmentController(AppointmentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            //get customers and appointments for admin list 
            var VM = new AppointmentListViewModel
            {
                Appointments = _context.Appointments.ToList(),
                Customers = _context.Customers.ToList(),
            };
            return View(VM);
        }

        [HttpGet]
        public IActionResult Add(int? appid)
        {
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();
            Appointment app;
            if (appid.HasValue && appid.Value != 0)
            {
                app = _context.Appointments.Find(appid.Value);
                if (app == null)
                {
                    return NotFound();
                }
            }
            else
            {
                app = new Appointment();
            }
           
            return View("AddEdit", app);
        }
        [HttpPost]
        public IActionResult Add(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                var customer = _context.Customers.FirstOrDefault(c => c.Username == appointment.Username);

                //create customer if one doesnt exist in DB
                if (customer == null)
                {
                    customer = new Customer
                    {
                        Username = appointment.Username,
                        PhoneNumber = appointment.PhoneNumber
                    };
                    _context.Customers.Add(customer);
                    _context.SaveChanges();
                }

                appointment.CustomerId = customer.CustomerId;

                if (appointment.AppointmentId == 0)
                {
                    _context.Appointments.Add(appointment);
                }
                else
                {
                    _context.Appointments.Update(appointment);
                }
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Customers = _context.Customers.ToList();
            return View("AddEdit", appointment);

        }

            //if(ModelState.IsValid)
            //{
            //    if(appointment.AppointmentId == 0)
            //    {
            //        _context.Appointments.Add(appointment);
            //    }
            //    else
            //    {
            //        _context.Appointments.Update(appointment);
            //    }
            //    _context.SaveChanges();
            //    return RedirectToAction("List");
            //}
            //ViewBag.Customers = _context.Customers.ToList();
            //return View("AddEdit", appointment);
        
        [HttpGet] 
        public IActionResult Delete(int appid)
        {
            var appointment = _context.Appointments.Find(appid);
            if(appointment != null)
            {
                return View(appointment);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult DeleteApp(int appid)
        {
            var app = _context.Appointments.Find(appid);
            if (app != null)
            {
                _context.Appointments.Remove(app);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}



     
  

