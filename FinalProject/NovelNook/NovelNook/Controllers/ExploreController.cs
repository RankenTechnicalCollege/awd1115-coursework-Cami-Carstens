using Microsoft.AspNetCore.Mvc;
using NovelNook.Models;
using NovelNook.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace NovelNook.Controllers
{
    public class ExploreController : Controller
    {
        private readonly SeedDataContext _context;
        public ExploreController(SeedDataContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString, int page =1)
        {
            int pageSize = 6;
          var cards = _context.ExploreCards.AsQueryable();
            
            //search feature
            if(!string.IsNullOrEmpty(searchString))
            {
                cards = cards.Where(c => c.Title.Contains(searchString)
                    || c.Author.Contains(searchString));
            }

            //Pagination
            var paginatedCards = await PaginatedList<ExploreCard>
                 .CreateAsync(cards.OrderBy(c => c.Title),
                 page, pageSize);

            ViewBag.SearchString = searchString;
            return View(paginatedCards);
        }
    }
}
