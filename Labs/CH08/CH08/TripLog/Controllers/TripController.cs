using Microsoft.AspNetCore.Mvc;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        private readonly TripContext _context;
        public TripController(TripContext context)
        {
            _context = context;
        }

        //get trip info
        [HttpGet]
        public IActionResult AddFirstStep()
        {
            ViewBag.SubHeader = "Add Trip Destination and Dates";
            return View(new TripPage1());
        }

        //post trip info
        [HttpPost]
        public IActionResult AddFirstStep(Trip trip)
        {
            if (ModelState.IsValid)
            {
                TempData["Destination"] = trip.Destination;
                TempData["Accommodation"] = trip.Accommodation;
                TempData["StartDate"] = trip.StartDate.ToString();
                TempData["EndDate"] = trip.EndDate.ToString();
                TempData.Keep();
                return RedirectToAction("AddSecondStep");
            }

            ViewBag.SubHeader = "Add Trip Destination and Dates";
            return View(trip);

        }

        [HttpGet]
        public IActionResult AddSecondStep()
        {
            var accommodation = TempData["Accommodation"]?.ToString() ?? "";
            ViewBag.SubHeader = $"Add Info for {accommodation}";
            TempData.Keep();
            return View(new TripPage2());
        }

        [HttpPost]
        public IActionResult AddSecondStep(TripPage2 trip)
        {
            
               
                TempData["AccomodationPhone"] = trip.AccommodationPhone;
                TempData["AccomodationEmail"] = trip.AccommodationEmail;
                TempData.Keep();
                return RedirectToAction("AddThirdStep");
            
        }

        [HttpGet]
        public IActionResult AddThirdStep()
        {
            var destination = TempData["Destination"]?.ToString() ?? "";
            ViewBag.SubHeader = $"Add Activities for {destination}";
            TempData.Keep();
            return View(new TripPage3());
        }

        [HttpPost]
        public IActionResult AddThirdStep(TripPage3 trip)
        {
            var newTripEntry = new Trip
            {
                Destination = TempData["Destination"]?.ToString() ?? "",
                Accommodation = TempData["Accommodation"]?.ToString() ?? "",
                StartDate = DateOnly.Parse(TempData["StartDate"]?.ToString() ?? ""),
                EndDate = DateOnly.Parse(TempData["EndDate"]?.ToString() ?? ""),
                AccommodationPhone = TempData["AccomodationPhone"]?.ToString(),
                AccommodationEmail = TempData["AccomodationEmail"]?.ToString(),
                Activity1 = trip.Activity1,
                Activity2 = trip.Activity2,
                Activity3 = trip.Activity3
            };
            
            _context.Trips.Add(newTripEntry);
            _context.SaveChanges();

            TempData.Clear();

            TempData["SuccessMessage"] = $"Trip to {newTripEntry.Destination} successfully added!";

            return RedirectToAction("Index", "Home");
        }

        //Cancel button
        [HttpPost]
        public IActionResult Cancel()
        {
            TempData.Clear();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
