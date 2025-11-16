using Microsoft.AspNetCore.Mvc;
using TripLog2.Models.DataAccess;
using TripLog2.Models.DomainModels;

namespace TripLog2.Controllers
{
    public class DestinationController : Controller
    {
        private Repository<Destination> data { get; set; }
        public DestinationController(TripLog2Context ctx)
        {
            //initialize the data variable to a new Repository of Destination type-and pass it ctx 
            data = new Repository<Destination>(ctx);
        }

        public IActionResult Index()
        {
            //get list from database of destinations ordered by name
            var destinations = data.List(new QueryOptions<Destination>
            {
                OrderBy = d => d.Name
            });
            return View(destinations);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Destination());
        }
        [HttpPost]
        public IActionResult Add(Destination model)
        {
            if(ModelState.IsValid)
            {
                data.Insert(model);
                data.Save();
                TempData["message"] = $"{model.Name} added.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
                     //id is model binding with the name prop in the View
        public IActionResult Delete(int id)
        {
            var destination = data.Get(id);
            data.Delete(destination);

            try
            {
                data.Save();
                TempData["message"] = $"{destination.Name} deleted";
                return RedirectToAction("Index");
            }
            catch
            {
                //remember we didnt allow cascading delete. So if there are trips associated with this destination, it will throw an exception.
                TempData["message"] = $"Unable to delete {destination.Name} because it is associated with a trip.";
                return RedirectToAction("Index");
            }
        }

    }
}
