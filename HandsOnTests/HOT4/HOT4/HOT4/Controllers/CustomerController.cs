using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using HOT4.Models.Validation;

namespace HOT4.Controllers
{
    public class CustomerController : Controller
    {
        private AppointmentContext _context {  get; set; }
        public CustomerController(AppointmentContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Customers = _context.Customers.OrderBy(c => c.Username).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            string input = Validate.CheckCustomer(_context, customer);
            if(!string.IsNullOrEmpty(input))
            {
                ModelState.AddModelError(nameof(Customer.Username), input);
            }
           
           if(ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                TempData["message"] = $"Customer {customer.Username} has been added!";
                return RedirectToAction("Index", "Home");
            }
           else
            {
                ViewBag.Customers = _context.Customers.OrderBy(c =>c.Username).ToList();
                return View();
            }
        }
    }
}
