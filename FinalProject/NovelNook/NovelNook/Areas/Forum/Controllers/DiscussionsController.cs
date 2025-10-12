using Microsoft.AspNetCore.Mvc;
using NovelNook.Areas.Forum.Models;

namespace NovelNook.Areas.Forum.Controllers
{
    [Area("Forum")]
    public class DiscussionsController : Controller
    {
        private readonly DiscussionContext _context;

        public DiscussionsController(DiscussionContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            var model = new DiscussionsViewModel
            {
                Discussions = _context.Discussions.ToList()
            };
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View(model);
        }

       
        [HttpPost]
       
        public IActionResult Index(DiscussionsViewModel model)
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








//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using NovelNook.Areas.Forum.Models;


//namespace NovelNook.Areas.Forum.Controllers
//{
//    [Area("Forum")]
//    public class DiscussionsController : Controller
//    {
//        private readonly DiscussionContext _context;

//        public DiscussionsController(DiscussionContext context)
//        {
//            _context = context;
//        }
//        [HttpGet]
//        public IActionResult Index()
//        {
//            var model = new DiscussionsViewModel
//            {
//                NewDiscussion = new Discussion(),
//                Discussions = _context.Discussions.ToList()
//            }; 
//            return View(model);

//            //var discussions = _context.Discussions;
//            //return View(discussions);
//        }

//        [HttpPost]
//        public IActionResult Index(DiscussionsViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Discussions.Add(model.NewDiscussion);
//                _context.SaveChanges();
//                model.Discussions = _context.Discussions.ToList();
//            }

//            model.Discussions = _context.Discussions.ToList();
//            return View(model);
//        }


//        public IActionResult Conversation()
//        {
//            var discussions = _context.Discussions.ToList();
//            return View(discussions);
//        }


//[HttpGet]
//public IActionResult Edit(int id)
//{
//    var discussion = _context.Discussions.Find(id);
//    if (discussion == null)
//    {
//        return NotFound();
//    }
//    return View(discussion);
//}
//[HttpPost]
//public IActionResult Edit(Discussion discussion)
//{
//    if (ModelState.IsValid)
//    {
//        _context.Discussions.Update(discussion);
//        _context.SaveChanges();
//        return RedirectToAction("Conversation");
//    }
//    return View(discussion);
//}

//[HttpGet]
//public IActionResult Delete(int id)
//{
//    var deleteDiscussion = _context.Discussions.Find(id);
//    if (deleteDiscussion == null)
//    {
//        return NotFound();
//    }
//    return View(deleteDiscussion);
//}
//        [HttpPost]

//        public IActionResult DeleteConfirmed(int id)
//        {
//            var discussion = _context.Discussions.Find(id);
//            if (discussion != null)
//            {
//                _context.Discussions.Remove(discussion);
//                _context.SaveChanges();
//            }
//            return RedirectToAction("Conversation", "Discussions", new { area = "Forum" });
//        }



//    }
//}
