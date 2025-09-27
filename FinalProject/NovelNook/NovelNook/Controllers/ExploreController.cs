using Microsoft.AspNetCore.Mvc;
using NovelNook.Models;
using NovelNook.Data;

namespace NovelNook.Controllers
{
    public class ExploreController : Controller
    {
        private readonly SeedDataContext _context;
        public ExploreController(SeedDataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
          var cards = _context.ExploreCards.ToList();
            return View(cards);
        }
    }
}
