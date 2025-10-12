using HOT3.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT3.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShopContext _context;
        private List<ShoppingCartItem> _cartItems;
        public ShoppingCartController(ShopContext context)
        {
            _context = context;
            _cartItems = new List<ShoppingCartItem>();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToCart(int id)
        {

            var hoodieToAdd = _context.Hoodies.Find(id);
            if (hoodieToAdd == null)
            {
                return NotFound();
            }
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var existingCartItem = cartItems
                .FirstOrDefault(item => item.Hoodie.Id == id);
            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                cartItems.Add(new ShoppingCartItem
                {
                    Hoodie = hoodieToAdd,
                    Quantity = 1
                });
            }

            HttpContext.Session.Set("Cart", cartItems);

            TempData["CartMessage"] = $"{hoodieToAdd.Name} has successfully been added to your cart.";

            return RedirectToAction("ViewCart");
        }

        public IActionResult ViewCart()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();

            var cartViewModel = new ShoppingCartViewModel
            {
                CartItems = cartItems,
                TotalPrice = cartItems.Sum(item => (item.Hoodie?.Price ?? 0) * item.Quantity),
                //TotalQuantity = cartItems.Sum(item => item.Quantity)
            };
            ViewBag.CartMessage = TempData["CartMessage"];

            return View(cartViewModel);
        }

        public IActionResult RemoveItem(int id)
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            var itemToRemove = cartItems.FirstOrDefault(item => item.Hoodie.Id == id);

            TempData["CartMessage"] = $"{itemToRemove.Hoodie.Name} successfully removed from cart.";
            if (itemToRemove != null)
            {
                if (itemToRemove.Quantity > 1)
                {
                    itemToRemove.Quantity--;
                }
                else
                {

                    cartItems.Remove(itemToRemove);
                }
            }
            HttpContext.Session.Set("Cart", cartItems);

            return RedirectToAction("ViewCart");
        }

        
        public IActionResult PurchaseItems()
        {
            var cartItems = HttpContext.Session.Get<List<ShoppingCartItem>>("Cart") ?? new List<ShoppingCartItem>();
            if (cartItems.Count == 0)
            {
                TempData["CartMessage"] = "Your cart is empty. Please add items to your cart before purchasing.";
                return RedirectToAction("ViewCart");
            }
            foreach (var item in cartItems)
            {
                _context.Purchases.Add(new Purchase
                {
                    HoodieId = item.Hoodie.Id,
                    PurchaseDate = DateTime.Now,
                    Quantity = item.Quantity,
                    TotalAmount = (item.Hoodie?.Price ?? 0) * item.Quantity

                });
            }
            _context.SaveChanges();
            TempData["CartMessage"] = "Your purchase was successful. We will email you when your order ships.";
            HttpContext.Session.Set("Cart", new List<ShoppingCartItem>());
            return RedirectToAction("ViewCart");
        }
    }
}
    


