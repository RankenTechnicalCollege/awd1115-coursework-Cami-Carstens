using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Controllers
{
    public class BookController : Controller
    {
        private Repository<Book> books;
        private readonly ApplicationDbContext _context;
        public BookController(ApplicationDbContext context)
        {
            _context = context;
            books = new Repository<Book>(context);
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await books.GetAllASync());
        //}

        //To search for a book

        public async Task<IActionResult> Index(string searchString, int page = 1)
        {
            int pageSize = 8;
            var cards = _context.Books.AsQueryable();

            //search feature
            if (!string.IsNullOrEmpty(searchString))
            {
                cards = cards.Where(c => c.Title.Contains(searchString)
                    || c.Author.Contains(searchString));
            }

            //Pagination
            var paginatedCards = await PaginatedList<Book>
                 .CreateAsync(cards.OrderBy(c => c.Title),
                 page, pageSize);

            ViewBag.SearchString = searchString;
            return View(paginatedCards);
        }

        public async Task<IActionResult> Details(int id, string? slug)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();

            return View(book);
        }

    }
}


        //public async Task<IActionResult> Details(int id)
        //{

        //    return View(await )
        //}
    

