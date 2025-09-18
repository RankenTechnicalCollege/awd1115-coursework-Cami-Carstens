using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CH04.Models;


namespace CH04.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ContactContext? _context;
        public DetailsController(ContactContext? context)
        {
            _context = context;
        }
        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }
    }
}
