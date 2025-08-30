using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project8
{
    public class Cart
    {
        private string _cartId;
        private Dictionary<string, double> _items;

        public Cart(string cartId)
        {
            _cartId = cartId;
            _items = new Dictionary<string, double>();
        }
        public void AddItem(string itemName, double price)
        {
            _items.Add(itemName, price);

        }

        public void RemoveItem(string itemName)
        {

            if (_items.ContainsKey(itemName))
            {
                _items.Remove(itemName);
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in the cart.");
            }
        }
        public double GetTotal()
        {
            double total = 0;
            foreach (var price in _items.Values)
            {
                total += price;
            }
            return total;

        }
        public void DisplayCart()
        {
            Console.WriteLine($"Cart ID: {_cartId}");
            Console.WriteLine("Items in Cart:");
            foreach (var item in _items)
            {
                Console.WriteLine($"- {item.Key}: ${item.Value:f2}");
            }
            Console.WriteLine($"Total: ${GetTotal():f2}");
        }
    }
}
