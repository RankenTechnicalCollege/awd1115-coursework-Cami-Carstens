using CH04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CH04.Controllers
{
    public class ContactController : Controller
    {
        private readonly ContactContext? _context;
        public ContactController(ContactContext? context)
        {
            _context = context;
        }

        [Route("contacts")]
        public async Task<IActionResult> List()
        {
            var contacts = await _context.Contacts.Include(c => c.Category).ToListAsync();
            return View(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var contactToDelete = await _context.Contacts.FindAsync(id);
            return View(contactToDelete);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Contact contact)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            if (id == 0)
            {
                ViewBag.Operation = "Add";
                return View(new Contact { Created = DateTime.Now });
            }
            else
            {
                ViewBag.Operation = "Edit";
                var contactToEdit = await _context.Contacts.FindAsync(id);
                return View(contactToEdit);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEdit(Contact contact)
        {
            ViewBag.Operation = contact.Id == 0 ? "Add" : "Edit";
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name", contact.CategoryId);
            if (ModelState.IsValid)
            {
                if(contact.Id == 0)
                {
                    _context.Contacts.Add(contact);
                }
                else
                {
                    _context.Contacts.Update(contact);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

           
            return View(contact);
        }
    }
}
