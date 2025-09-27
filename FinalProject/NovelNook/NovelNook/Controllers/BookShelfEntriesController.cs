using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NovelNook.Data;
using NovelNook.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace NovelNook.Controllers
{
    //base route-on load
    //make plural(#3)
    [Route("books/")]
    public class BookShelfEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public BookShelfEntriesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: BookShelfEntries /books
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var entries = await _context.BookshelfEntries
                .Where(b => b.IdentityUserId == userId)
                .ToListAsync();
            return View(entries);
        }

        //GET: 
        [HttpGet("book/{id}/{slug}/")]
        public async Task<IActionResult> Details(int? id, string slug)
        {
            var bookShelfEntry = await _context.BookshelfEntries
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bookShelfEntry == null)
            {
                return NotFound();
            }

            if(bookShelfEntry.Slug != slug)
            {
                return RedirectToAction("Details", new { id = bookShelfEntry.Id, slug = bookShelfEntry.Slug });
            }

            return View(bookShelfEntry);
        }

        //GET: BookShelfEntries/Create
        [HttpGet("create/")]
        public IActionResult Create()
        {
            var userId = _userManager.GetUserId(User);
            var model = new BookShelfEntry
            {
                IdentityUserId = userId,
                AddedDate = DateTime.Today
            };
            return View(model);
        }

        // POST: BookShelfEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("create/")]
       
        public async Task<IActionResult> Create([Bind("Id,Author,Title,StatusMessage,AddedDate,IdentityUserId")] BookShelfEntry bookShelfEntry)
        {
            if (ModelState.IsValid)
            {
                bookShelfEntry.IdentityUserId = _userManager.GetUserId(User);
                _context.Add(bookShelfEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", bookShelfEntry.IdentityUserId);
            return View(bookShelfEntry);
            //return RedirectToAction(nameof(Index));
        }

        //CREATE METHOD FOR ADDING BOOK FROM EXPLORE PAGE TO THE BOOKSHELF PAGE THROUGH CREATE PAGE

        [HttpPost("add-to-bookshelf/")]
        
        public async Task<IActionResult> AddBook([Bind("Title", "Author")] BookShelfEntry bookShelfEntry)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Explore");
            }
            var userId = _userManager.GetUserId(User);
            bool ifExists = await _context.BookshelfEntries.AnyAsync(b => b.Title == bookShelfEntry.Title && b.Author == bookShelfEntry.Author && b.IdentityUserId == userId);

            if(ifExists)
            {
                return RedirectToAction(nameof(Index));
            }
            bookShelfEntry.IdentityUserId = userId;
            bookShelfEntry.StatusMessage = "Future Read";
            bookShelfEntry.AddedDate = DateTime.Now;

            _context.Add(bookShelfEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        

        // GET: 
        [HttpGet("book/edit/{id}/{slug}")]
        public async Task<IActionResult> Edit(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShelfEntry = await _context.BookshelfEntries.FindAsync(id);
            if (bookShelfEntry == null)
            {
                return NotFound();
            }
            if(bookShelfEntry.IdentityUserId != _userManager.GetUserId(User))
            {
                return Unauthorized();
            }

            if(bookShelfEntry.Slug != slug)
            {
                return RedirectToAction("Edit", new { id = bookShelfEntry.Id, slug = bookShelfEntry.Slug });
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", bookShelfEntry.IdentityUserId);
            return View(bookShelfEntry);
        }

        // POST: BookShelfEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("book/edit/{id}/{slug}/")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Author,Title,StatusMessage,AddedDate,IdentityUserId")] BookShelfEntry bookShelfEntry)
        {
            if (id != bookShelfEntry.Id)
            {
                return NotFound();
            }

            var existing = await _context.BookshelfEntries.FirstOrDefaultAsync(b => b.Id == id);
            if (existing == null || existing.IdentityUserId != _userManager.GetUserId(User))
            {
                return Unauthorized();
            }

            if (ModelState.IsValid)
            {

                existing.Author = bookShelfEntry.Author;
                existing.Title = bookShelfEntry.Title;
                existing.StatusMessage = bookShelfEntry.StatusMessage;
                existing.AddedDate = bookShelfEntry.AddedDate;
                try

                {
                //    _/*context.Update(bookShelfEntry);*/
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookShelfEntryExists(bookShelfEntry.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", bookShelfEntry.IdentityUserId);
            return View(bookShelfEntry);
        }


        // GET: 
        [HttpGet("book/delete/{id}/{slug}")]
        public async Task<IActionResult> Delete(int? id, string slug)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookShelfEntry = await _context.BookshelfEntries
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookShelfEntry == null || bookShelfEntry.IdentityUserId != _userManager.GetUserId(User))
            {
                return NotFound();
            }

            return View(bookShelfEntry);
        }

        // POST: BookShelfEntries/Delete/5
        [HttpPost("book/delete/{id}/{slug}/"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookShelfEntry = await _context.BookshelfEntries.FindAsync(id);
            if (bookShelfEntry != null || bookShelfEntry.IdentityUserId != _userManager.GetUserId(User))
            {
                _context.BookshelfEntries.Remove(bookShelfEntry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookShelfEntryExists(int id)
        {
            return _context.BookshelfEntries.Any(e => e.Id == id);
        }

    }
    
}
