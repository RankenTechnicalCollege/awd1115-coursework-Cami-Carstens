using HOT3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOT3.Controllers
{
    public class HoodieController : Controller
    {
        private readonly ShopContext _context;
        public HoodieController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index(string? brand)
        {
            //1.) get all hoodies from the database
            var hoodies = _context.Hoodies.Include(h => h.Category).ToList();

            //2.) filter by brand if category is not null or empty
            if (!string.IsNullOrEmpty(brand))
            {
                hoodies = hoodies.Where(h => h.Brand != null && h.Brand.ToLower() == brand.ToLower()).ToList();
            }
            return View(hoodies);

        }
    }
}
