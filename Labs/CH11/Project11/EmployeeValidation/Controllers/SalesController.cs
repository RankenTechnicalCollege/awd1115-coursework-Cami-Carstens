using EmployeeValidation.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeeValidation.Models.Validation;

namespace EmployeeValidation.Controllers
{
    public class SalesController : Controller
    {
        private SalesContext context;
        public SalesController(SalesContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Employees = context.Employees.OrderBy(e => e.LastName).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Add(Sales sale)
        {
            string msg = Validate.CheckSales(context, sale);
            if(!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Sales.EmployeeId), msg);
            }
            if(ModelState.IsValid)
            {
                context.Sales.Add(sale);
                context.SaveChanges();
                TempData["message"] = "Sale Added";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Employees = context.Employees.OrderBy(e =>e.LastName).ToList();
                return View();

            }
        }
    }
}
