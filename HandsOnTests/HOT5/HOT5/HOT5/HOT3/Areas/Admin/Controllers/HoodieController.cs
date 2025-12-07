using HOT3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HOT3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HoodieController : Controller
    {
        private readonly ShopContext _context;
        public HoodieController(ShopContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var hoodies = _context.Hoodies.ToList();
            return View(hoodies);
        }
        [HttpGet]
        public IActionResult Add(int? id)
        {
           Hoodie hoodie;
            if (id.HasValue && id.Value != 0)
            {
                hoodie = _context.Hoodies.Find(id.Value);
                if (hoodie == null)
                {
                    return NotFound();
                }
            }
            else
            {
                    hoodie = new Hoodie();
            }
          return View("AddEdit", hoodie);
        }
           
        
        [HttpPost]
        public IActionResult Add(Hoodie hoodie)
        {
            if(ModelState.IsValid)
            {
                if(hoodie.Id == 0)
                {
                    _context.Hoodies.Add(hoodie);
                }
                else
                {
                    _context.Hoodies.Update(hoodie);

                }
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View("AddEdit", hoodie);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hoodie = _context.Hoodies.Find(id);
            if (hoodie != null)
            {
                return View(hoodie);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult DeleteHoodie(int id)
        {
            var hoodie = _context.Hoodies.Find(id);
            if(hoodie != null)
            {
                _context.Hoodies.Remove(hoodie);
                _context.SaveChanges();

            }
            return RedirectToAction("List");
        }
    }
}
