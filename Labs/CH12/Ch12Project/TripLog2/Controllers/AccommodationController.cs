using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TripLog2.Models.DataAccess;
using TripLog2.Models.DomainModels;

namespace TripLog2.Controllers
{
    public class AccommodationController : Controller
    {
        private Repository<Accommodation> data { get; set; }

        public AccommodationController(TripLog2Context ctx)
        {
            data = new Repository<Accommodation>(ctx);
        }

        public IActionResult Index()
        {
            var accommodations = data.List(new QueryOptions<Accommodation>
            {
                Where = a => a.AccommodationId > 0,
                OrderBy = a => a.Name
            });
            return View(accommodations);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var accommodation = data.Get(id);

            if (accommodation == null)
            {
                
                TempData["message"] = "Accommodation not found.";
                return RedirectToAction("Index");
            }
           
            try
            {
                data.Delete(accommodation);
                data.Save();
                TempData["message"] = $"{accommodation.Name} deleted";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["message"] = $"Unable to delete {accommodation.Name} because it is associated with a trip.";
                //view needs a list of accommodations
                var accommodations = data.List(new QueryOptions<Accommodation>
                {
                    Where = a => a.AccommodationId > 0,
                    OrderBy = a => a.Name
                });
                return View("Index", accommodations);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Accommodation());
        }

        [HttpPost] 
        public IActionResult Add(Accommodation accommodation)
        {
            if(ModelState.IsValid)
            {
                data.Insert(accommodation);
                data.Save();
                TempData["message"] = $"{accommodation.Name} added.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(accommodation);
            }
        }
    }
}
