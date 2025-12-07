using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;
using static System.Reflection.Metadata.BlobBuilder;

namespace NovelNookBookStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class DecorController : Controller
    {
        private Repository<Decor> decors;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DecorController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            decors = new Repository<Decor>(context);
            _webHostEnvironment = webHostEnvironment;

        }

        public async Task<IActionResult> Index()
        {
            return View(await decors.GetAllASync());

        }
        public async Task<IActionResult> Details()
        {
            return View(await decors.GetAllASync());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DecorId, Title")] Decor decor)
        {
            if (ModelState.IsValid)
            {
                await decors.AddASync(decor);
                return RedirectToAction("Index");
            }
            return View(decor);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await decors.GetByIdAsync(id, new QueryOptions<Decor>());
            if (book == null)
                return NotFound();

            return View(book);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Decor decor)
        {
            await decors.DeleteAsync(decor.DecorId);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Decor());
            }
            else
            {
                var decor = await _context.Decors.FindAsync(id);
                if (decor == null)
                    return NotFound();

                return View(decor);
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Decor decor)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            ViewBag.Operation = decor.DecorId == 0 ? "Add" : "Edit";

            if (decor.CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Please select a category.");
                return View(decor);
            }

            if (ModelState.IsValid)
            {
                if (decor.ImageFile != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + decor.ImageFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await decor.ImageFile.CopyToAsync(fileStream);
                    }

                    decor.ImageUrl = "/Images/" + uniqueFileName;
                }
                try
                {
                    // Save to database
                    if (decor.DecorId == 0)
                    {
                        _context.Decors.Add(decor);
                    }
                    else
                    {
                        var existingDecor = await _context.Decors.FindAsync(decor.DecorId);
                        if (existingDecor != null)
                        {
                            existingDecor.Name = decor.Name;
                            existingDecor.Description = decor.Description;
                            existingDecor.Price = decor.Price;
                            existingDecor.Stock = decor.Stock;
                            existingDecor.CategoryId = decor.CategoryId;

                            if (decor.ImageFile != null)
                            {
                                existingDecor.Image = decor.Image;
                                existingDecor.ImageUrl = decor.ImageUrl;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", "Decor");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error saving to database: " + ex.Message);
                    return View(decor);
                }
            }

            return View(decor);
        }
    }
}
