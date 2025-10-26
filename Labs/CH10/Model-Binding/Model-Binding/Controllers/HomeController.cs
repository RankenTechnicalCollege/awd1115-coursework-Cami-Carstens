using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Model_Binding.Models;

namespace Model_Binding.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
        //THREE ways to bind data to action method parameters
        //1)Http Body of a post request
        //2) Model binding using route data
        //3) Model binding using a query string

        [HttpPost]
        public IActionResult Index(Record record)
        {
            return View(record);
        }

        [Route("/records/{id?}/{name?}")]

       //decorating parameters to tell it where to get.
       //EXAMPLE:inside parameter ([FromQuery)Record r) or [FromRoute]
        public IActionResult GetRecord(Record r)
        {
            return Content($"the record id is {r.Id} and the name is {r.Name}");
        }

        [HttpPost]

                               //leave Description off and only bind to 2 properties
                               //[BindNever] could be applied to the model.cs Description property
        public IActionResult AddMusician([Bind("Id, Name")]Musician m)
        {
            return Content($"The musician id is {m.Id} and the name is {m.Name}");
        }
        public IActionResult AddData(string[] StudentNames)
        {
            string result = "";
            foreach(var name in StudentNames)
            {
                result += name + " ";
            }
            return Content(result);

        }
     
    }
}
