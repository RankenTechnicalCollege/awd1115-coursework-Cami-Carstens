using GearheadAutoParts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace GearheadAutoParts.Controllers
{
   
    public class ProductController : Controller
    {
        //make the connection to the database
        private readonly SalesContext _context;

        
        public ProductController(SalesContext context)
        {
            _context = context;
        }
        [Route("products")]
        public async Task<IActionResult> List()
        {
        var products = await _context.Product.Include(p => p.Category).ToListAsync();
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id=0)
        {
            ViewBag.Categories = new SelectList( await _context.Categories.ToListAsync(), "CategoryId", "CategoryName");
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Product());
            }
            else
            {
                ViewBag.Operation = "Edit";
                var product = await _context.Product.FindAsync(id);
                if(product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(Product product)
        {
           ViewBag.Operation = product.ProductId == 0 ? "Add" : "Edit";
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "CategoryId", "CategoryName", product.CategoryId);
            if (ModelState.IsValid)
            {
                if(product.ProductId == 0)
                {
                    _context.Product.Add(product);
                }
                else
                {
                    _context.Product.Update(product);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
          var deleteProduct = await _context.Product.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
            if(deleteProduct == null)
            {
                return NotFound();
            }
            return View(deleteProduct);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if(product == null)
            {
                return NotFound();
            }
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
