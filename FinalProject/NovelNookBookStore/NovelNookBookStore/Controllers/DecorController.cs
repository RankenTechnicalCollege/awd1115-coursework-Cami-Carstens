using Microsoft.AspNetCore.Mvc;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Controllers
{
    public class DecorController : Controller
    {
        private Repository<Decor> decors;
        private readonly ApplicationDbContext _context;
        public DecorController(ApplicationDbContext context)
        {
            _context = context;
            decors = new Repository<Decor>(context);
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await decors.GetAllASync());
        //}

        public async Task<IActionResult> Index(string? searchString, int page = 1)
        {
            int pageSize = 6;

            
            var cards = _context.Decors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                cards = cards.Where(b => b.Name.Contains(searchString));
                                      
            }

            var paginatedCards = await PaginatedList<Decor>
                 .CreateAsync((IQueryable<Decor>)cards.OrderBy(b => b.Name), page, pageSize);

            ViewBag.SearchString = searchString;
            return View(paginatedCards);
        }

        public async Task<IActionResult> Details(int id, string? slug)
        {
            var decor = await _context.Decors.FindAsync(id);
            if (decor == null)
                return NotFound();

            return View(decor);
        }



    }
}
    

