using Microsoft.AspNetCore.Mvc;
using EmployeeValidation.Models;
using EmployeeValidation.Models.Validation;

namespace EmployeeValidation.Controllers
{
    public class ValidationController : Controller
    {
        private SalesContext context {  get; set; }
        public ValidationController(SalesContext context) 
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult CheckEmployee(DateTime dob, string firstname, string lastname)
        {
            Employee employee = new Employee { FirstName = firstname, LastName = lastname, DOB = dob };
            string msg = Validate.CheckEmployee(context, employee);

            if(string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }

        }
        public JsonResult CheckManager(int managerId, string firstname, string lastname, DateTime dob)
        {
            var employee = new Employee { FirstName=firstname, LastName=lastname, ManagerId = managerId, DOB = dob };

            string msg = Validate.CheckManagerEmployeeMatch(context, employee);
            if(string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }
        public JsonResult CheckSales(int quarter, int year, int employeeId)
        {
            var sales = new Sales { Quarter = quarter, EmployeeId = employeeId, Year=year };
            string msg = Validate.CheckSales(context, sales);
            if(string.IsNullOrEmpty(msg))
            {
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }
    }
}
