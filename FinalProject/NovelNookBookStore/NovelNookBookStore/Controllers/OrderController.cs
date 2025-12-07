using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.IdentityModel.Tokens;
using NovelNookBookStore.Data;
using NovelNookBookStore.Models;
using NovelNookBookStore.Models.DataLayer;
using NovelNookBookStore.Models.DomainModels;
using NovelNookBookStore.Models.ViewModels;


namespace NovelNookBookStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Repository<Book> _books;
        private Repository<Decor> _decors;
        private Repository<Order> _orders;
        private Repository<Sale> _sales;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _books = new Repository<Book>(context);
            _decors = new Repository<Decor>(context);
            _orders = new Repository<Order>(context);
            _sales = new Repository<Sale>(context);
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }

       
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel") ?? new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                Books = await _books.GetAllASync(),
                Decors = await _decors.GetAllASync(),
                Sales = await _sales.GetAllASync()
            };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItem(int bookId, int bookQty, int decorId, int decorQty, int saleId = 0, int saleQty = 0)
        {
            var book = await _context.Books.FindAsync(bookId);
            var decor = await _context.Decors.FindAsync(decorId);
            var sale = saleId > 0 ? await _context.Sales.FindAsync(saleId) : null;

            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel") ?? new OrderViewModel
            {
                OrderItems = new List<OrderItemViewModel>(),
                Books = await _books.GetAllASync(),
                Decors = await _decors.GetAllASync(),
                Sales = await _sales.GetAllASync()
            };

            // BOOK
            if (bookQty > 0 && book != null)
            {
                var existingBook = model.OrderItems.FirstOrDefault(x => x.BookId == bookId);
                if (existingBook != null)
                {
                    existingBook.Quantity += bookQty;
                }
                else
                {
                    model.OrderItems.Add(new OrderItemViewModel
                    {
                        BookId = book.BookId,
                        BookTitle = book.Title,
                        Price = book.Price,
                        Quantity = bookQty
                    });
                }
            }

            // DECOR
            if (decorQty > 0 && decor != null)
            {
                var existingDecor = model.OrderItems.FirstOrDefault(x => x.DecorId == decorId);
                if (existingDecor != null)
                {
                    existingDecor.Quantity += decorQty; 
                }
                else
                {
                    model.OrderItems.Add(new OrderItemViewModel
                    {
                        DecorId = decor.DecorId,
                        DecorName = decor.Name,
                        Price = decor.Price,
                        Quantity = decorQty
                    });
                }
            }

            //Sale stuff
            if(saleQty > 0 && sale != null)
            {
                var existingSale = model.OrderItems.FirstOrDefault(s => s.SaleItemId == saleId);
                if(existingSale != null)
                {
                    existingSale.Quantity += saleQty;
                }
                else
                {
                    model.OrderItems.Add(new OrderItemViewModel
                    {
                        SaleItemId = sale.SaleId,
                        SaleItemName = sale.SaleItemName,
                        Price = sale.SalePrice,
                        Quantity = saleQty
                    });
                }
            }

            // Recalculate total
            model.Subtotal = model.OrderItems.Sum(x => x.Price * x.Quantity);
            model.TaxAmount = model.Subtotal * model.TaxRate;
            model.TotalAmount = model.Subtotal + model.TaxAmount;
   

            HttpContext.Session.Set("OrderViewModel", model);

            return RedirectToAction("Create");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Cart()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null)
            {
                model = new OrderViewModel
                {
                    OrderItems = new List<OrderItemViewModel>(),
                    TotalAmount = 0
                };
            }

            return View(model);
        }


        [HttpPost]
        [Authorize]
      
        public async Task<IActionResult> PlaceOrder()
        {
            var model = HttpContext.Session.Get<OrderViewModel>("OrderViewModel");

            if (model == null || model.OrderItems.Count == 0)
            {
                return RedirectToAction("Create");
            }

            Order order = new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = model.TotalAmount,
                UserId = _userManager.GetUserId(User),
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in model.OrderItems)
            {
                if (item.BookId > 0)
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                if (item.DecorId > 0)
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        DecorId = item.DecorId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }
                if(item.SaleItemId > 0 )
                {
                    order.OrderItems.Add(new OrderItem
                    {
                        SaleItemId = item.SaleItemId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }
            }

            await _orders.AddASync(order);

            HttpContext.Session.Remove("OrderViewModel");
            return RedirectToAction("ViewOrder");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ViewOrder()
        {
            var userId = _userManager.GetUserId(User);
            var userOrders = await _orders.GetAllByIdAsync(userId, "UserId", new QueryOptions<Order>
            {
                Includes = "OrderItems.Book, OrderItems.Decor"
            });
            return View(userOrders);
        }

    }
}