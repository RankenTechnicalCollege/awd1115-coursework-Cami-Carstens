
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;
using System.Threading.Tasks;



namespace NovelNookBookStore.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BookController : Controller
    {
        private Repository<Book> books;
        private readonly ApplicationDbContext _context;
        private Repository<Category> categories;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            books = new Repository<Book>(context);
            categories = new Repository<Category>(context);
            _webHostEnvironment = webHostEnvironment;

        }

        public async Task<IActionResult> Index()
        {
            return View(await books.GetAllASync());

        }
        public async Task<IActionResult> Details()
        {
            var model = await books.GetAllASync();
            return View(model);
        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId, Title")] Book book)
        {
            if (ModelState.IsValid)
            {
                await books.AddASync(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var book = await books.GetByIdAsync(id, new QueryOptions<Book>());
        //    if (book == null)
        //        return NotFound();

        //    return View(book);
          
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await books.DeleteAsync(id);
                return RedirectToAction("Details");
            }
            catch
            {
                ModelState.AddModelError("", "Product not found.");
                return RedirectToAction("Details");
            }

        }





        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            var categoriesList = await _context.Categories.ToListAsync();
            ViewBag.Categories = categoriesList ?? new List<Category>();

            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Book());
            }
            else
            {

                ViewBag.Operation = "Edit";
                var book = await _context.Books.FindAsync(id);
                if (book == null)
                {
                    return NotFound();
                }
                return View(book);
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Book book)
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();

            if (!ModelState.IsValid)
                return View(book);

            // Upload image only if a file was selected
            if (book.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid() + "_" + book.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await book.ImageFile.CopyToAsync(stream);
                }

                book.Image = "/Images/" + uniqueFileName; 
                book.ImageUrl = book.Image;
            }

            if (book.BookId == 0) // New book
            {
                await books.AddASync(book);
            }
            else // Existing book
            {
                var existingBook = await books.GetByIdAsync(book.BookId, new QueryOptions<Book>());
                if (existingBook == null)
                    return NotFound();

                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.Price = book.Price;
                existingBook.Stock = book.Stock;
                existingBook.CategoryId = book.CategoryId;

                // Only update image if a new file was uploaded
                if (book.ImageFile != null)
                {
                    existingBook.Image = book.Image;
                    existingBook.ImageUrl = book.ImageUrl;
                }

                await books.UpdateASync(existingBook);
            }

            return RedirectToAction("Details");
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddEdit(Book book)
        //{

        //    //2:30:30
        //    ViewBag.Categories = await _context.Categories.ToListAsync();
        //    //ViewBag.Operation = book.BookId == 0 ? "Add" : "Edit";

        //    if (ModelState.IsValid)
        //    {
        //        if (book.ImageFile != null)
        //        {
        //            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

        //            string uniqueFileName = Guid.NewGuid().ToString() + "_" + book.ImageFile.FileName;
        //            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await book.ImageFile.CopyToAsync(fileStream);
        //            }
        //            book.Image = "/Images/" + uniqueFileName;
        //            book.ImageUrl = book.Image;

        //        }


        //        if (book.CategoryId == 0)
        //        {
        //            ModelState.AddModelError("CategoryId", "Please select a category.");
        //            return View(book);
        //        }

        //        if (book.BookId == 0)
        //        {
        //            ViewBag.Categories = await categories.GetAllASync();

        //            await books.AddASync(book);
        //        }
        //        else
        //        {

        //            var existingBook = await books.GetByIdAsync(book.BookId, new QueryOptions<Book>());

        //            if (existingBook == null)
        //            {
        //                ViewBag.Books = await books.GetAllASync();
        //                ViewBag.Categories = await categories.GetAllASync();
        //                return View(book);
        //            }

        //            existingBook.Title = book.Title;
        //            existingBook.Description = book.Description;
        //            existingBook.Author = book.Author;
        //            existingBook.Price = book.Price;
        //            existingBook.Description = book.Description;
        //            existingBook.Stock = book.Stock;
        //            existingBook.CategoryId = book.CategoryId;

        //            if (book.ImageFile != null)
        //            {
        //                existingBook.Image = book.Image;
        //                existingBook.ImageUrl = book.ImageUrl;
        //            }
        //            await books.UpdateASync(existingBook);
        //        }
        //        return RedirectToAction("Details");
        //    }
        //    return View(book);
        //}
    }
}






