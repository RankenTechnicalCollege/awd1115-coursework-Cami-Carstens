using Microsoft.AspNetCore.Mvc;

using TripLog2.Models;
using TripLog2.Models.DataAccess;
using TripLog2.Models.DomainModels;
using TripLog2.Models.Utilities;

namespace TripLog2.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Trip> data { get; set; }
        private Repository<Destination> destinationData { get; set; }
        private Repository<Accommodation> accommodationData { get; set; }
        private Repository<Models.DomainModels.Activity> activityData { get; set; }
     

        public HomeController(TripLog2Context ctx)
        {
            data = new Repository<Trip>(ctx);
            destinationData = new Repository<Destination>(ctx);
            accommodationData = new Repository<Accommodation>(ctx);
            activityData = new Repository<Activity>(ctx);
        }
        public IActionResult Index()
        {
            var options = new QueryOptions<Trip>
            {
                Includes = "Destination, Accommodation, Activities",
                OrderBy = t => t.StartDate!
            };
            var trips = data.List(options);
            return View(trips);
        }

        [HttpGet]
        public IActionResult Add(string? id)
        {
            if (string.IsNullOrEmpty(id) || id == "Page1")
            {
                return View("Page1", new Trip());
            }
            if (id == "Page2")
            {
                Trip? trip = TempData.Get<Trip>("Trip");
                if (trip == null)
                    return RedirectToAction("Add", new { id = "Page1" });

                // Load activity list for the Page2 view
                ViewBag.Activities = activityData.List(new QueryOptions<Activity>());
                ViewBag.Destinations = destinationData.List(new QueryOptions<Destination>());
                ViewBag.Accommodations = accommodationData.List(new QueryOptions<Accommodation>());


                TempData.Keep("Trip");
                return View("Page2", trip);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]

        public IActionResult Page1Next(Trip trip)
        {
            if (!ModelState.IsValid)
                return View("Page1", trip);

            //does the destination exist? 
            var dest = destinationData
            .List(new QueryOptions<Destination>())
            .FirstOrDefault(d => d.Name == trip.DestinationName);

            //if not insert it
            if (dest == null)
            {
                dest = new Destination
                {
                    Name = trip.DestinationName
                };
                destinationData.Insert(dest);
                destinationData.Save();
            }
            trip.DestinationId = dest.DestinationId;

            //does the accommodation exist?
            var accomm = accommodationData
             .List(new QueryOptions<Accommodation>())
               .FirstOrDefault(a => a.Name == trip.AccommodationName);
            if (accomm == null)
            {
                accomm = new Accommodation
                { Name = trip.AccommodationName };
                accommodationData.Insert(accomm);
                accommodationData.Save();
            }
            trip.AccommodationId = accomm.AccommodationId;


            //keep the trip in tempdata for page2
            TempData.Put("Trip", trip);
            return RedirectToAction("Add", new { id = "Page2" });
        }

        [HttpPost]

        public IActionResult Page2Add(Trip trip, string[] selectedActivities)
        {
            Trip? newSavedTrip = TempData.Get<Trip>("Trip");

            if (newSavedTrip == null)
                return RedirectToAction("Add", new { id = "Page1" });

            //get page 1 fields
            trip.DestinationId = newSavedTrip.DestinationId;
            trip.AccommodationId = newSavedTrip.AccommodationId;
            trip.StartDate = newSavedTrip.StartDate;
            trip.EndDate = newSavedTrip.EndDate;

            //after getting page 1 fields add activities from page2

            trip.Activities = selectedActivities
            .Where(a => !string.IsNullOrEmpty(a))
            .Select(a => new Activity { Name = a })
            .ToList();
            //trip.Activities = new List<Activity>();

            //foreach (var name in selectedActivities)
            //{
            //    trip.Activities.Add(new Activity { Name = name });
            //}

            data.Insert(trip);
            data.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var tripOpt = new QueryOptions<Trip>
            {
                Includes = "Destination, Accommodation, Activities",
                    Where = t => t.TripId == id
            };
            var trip = data.Get(tripOpt);

            if(trip == null)
            {
                return RedirectToAction("Index");
            }
            try
            {
                data.Delete(trip);
                data.Save();
                var destName = trip.Destination?.Name ?? trip.DestinationName ?? "destination";

                TempData["message"] = $"Trip to {destName} deleted";
            }
            catch
            {
                TempData["message"] = "Unable to delete trip";
            }
            return RedirectToAction("Index");
        }
    }
}
