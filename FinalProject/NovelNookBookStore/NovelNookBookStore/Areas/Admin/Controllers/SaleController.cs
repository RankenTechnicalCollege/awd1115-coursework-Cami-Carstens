using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;
using System.Threading.Tasks;

namespace NovelNookBookStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly Repository<Sale> _sales;
        private readonly ApplicationDbContext _context;

        //for uploading pics
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SaleController(ApplicationDbContext ctx, IWebHostEnvironment webHostEnvironment)
        {
            _context = ctx;
            _sales = new Repository<Sale>(ctx);
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Details()
        {
            var sales = await _sales.GetAllASync();
            return View(sales);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Sale());
            }
            else
            {
                ViewBag.Operation = "Edit";
                var sale = await _sales.GetByIdAsync(id, new QueryOptions<Sale>());


                if (sale == null)
                {
                    return NotFound();
                }
                return View(sale);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Sale sale)
        {
            if(!ModelState.IsValid)
            {
                return View(sale);
            }

            if(sale.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid() + "_" + sale.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await sale.ImageFile.CopyToAsync(stream);
                }
                sale.ImageUrl = "/Images/" + uniqueFileName;

            }
            if(sale.SaleId == 0)
            {
                await _sales.AddASync(sale);
            }
            else
            {
                var existingSale = await _sales.GetByIdAsync(sale.SaleId, new QueryOptions<Sale>());
                if(existingSale == null)
                {
                    return NotFound();
                }
                existingSale.SaleItemName = sale.SaleItemName;
                existingSale.SaleDescription = sale.SaleDescription;
                existingSale.SalePrice = sale.SalePrice;
                existingSale.IsOnSale = sale.IsOnSale;

                if(sale.ImageFile != null)
                {
                    existingSale.ImageUrl = sale.ImageUrl;
                }
                
                await _sales.UpdateASync(existingSale);
                
            }
            return RedirectToAction("Details", "Sale");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _sales.GetByIdAsync(id, new QueryOptions<Sale>());
            if (sale == null)
                return NotFound();
            return View(sale);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sales.DeleteAsync(id);
            return RedirectToAction("List", "Sale", new { area = "Admin" });
            
        }
    }
}
