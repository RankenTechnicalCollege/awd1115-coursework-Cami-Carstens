using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Areas.Help.Controllers
{
    [Area("Help")]
    public class TutorialController : Controller
    {

      //method for which tutorial page view
        public IActionResult Index(int id)
        {
            //ViewBag.ActiveTab = "Tutorial";
            ViewBag.ActivePage = id.ToString();
            if (id == 1)
            {
                return View("Page1");
            }
            else if(id == 2)
            {
                return View("Page2");
            }
            else if (id == 3) 
            {
                return View("Page3");
            }
            return View("Page1");
                
        }
    }
}
