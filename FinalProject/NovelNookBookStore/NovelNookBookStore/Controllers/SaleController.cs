using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;
using NovelNookBookStore.Models.ViewModels;
using System.Linq;

namespace NovelNookBookStore.Controllers
{
    public class SaleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var saleItems = _context.Sales
                    .Where(s => s.IsOnSale)
                    .ToList();

            return View(saleItems);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int saleId, int quantity = 1)
        {
            var saleItem = _context.Sales.Find(saleId);
            if (saleItem == null || quantity <= 0)
                return RedirectToAction("List");

            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel") ?? new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>()
            };

            var existing = model.OrderItems.FirstOrDefault(x => x.SaleItemId == saleId);
            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                model.OrderItems.Add(new OrderItemViewModel
                {
                    SaleItemId = saleItem.SaleId,
                    SaleItemName = saleItem.SaleItemName,
                    Price = saleItem.SalePrice,
                    Quantity = quantity
                });
            }
            model.TotalAmount = model.OrderItems.Sum(x => x.Price * x.Quantity);
            HttpContext.Session.Set("OrderViewModel", model);

            return RedirectToAction("List");
        }
    }
}
    


