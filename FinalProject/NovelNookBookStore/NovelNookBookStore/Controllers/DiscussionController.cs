using Microsoft.AspNetCore.Mvc;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models;

namespace NovelNookBookStore.Controllers
{
    public class DiscussionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiscussionController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var model = new DiscussionViewModel
            {
                Discussions = _context.Discussions.ToList()
            };
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(model);
        }


        [HttpPost]

        public IActionResult Index(DiscussionViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Discussions.Add(model.NewDiscussion);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Discussion entry was successfully added to forum.";
                return RedirectToAction(nameof(Index));
            }

            model.Discussions = _context.Discussions.ToList();
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var discussion = _context.Discussions.Find(id);
            if (discussion == null) return NotFound();
            return View(discussion);
        }


        [HttpPost]

        public IActionResult Edit(Discussion discussion)
        {
            if (ModelState.IsValid)
            {
                _context.Discussions.Update(discussion);

                _context.SaveChanges();
                TempData["SuccessMessage"] = "Discussion entry was updated.";
                return RedirectToAction(nameof(Index));
            }
            return View(discussion);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var discussion = _context.Discussions.Find(id);
            if (discussion == null)
            {
                return NotFound();
            }
            _context.Discussions.Remove(discussion);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Discussion entry was successfully deleted.";
            return RedirectToAction(nameof(Index));
        }
    }
}
    

