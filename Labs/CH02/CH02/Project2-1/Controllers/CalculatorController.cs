using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project2_1.Models;

namespace Project2_1.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //create an instance of the model class
            var model = new Calculate();
            //start model at 0
            model.BillAmount = 0;

            //send model to the view
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(Calculate model)
        {
           if(ModelState.IsValid)
            {
                //model.BillAmount = 0;
                //send model to the results view
                return View("Index", model);
            }
           else
            {
                model.BillAmount = 0;
            }
                return View(model);
        }
    }
}
