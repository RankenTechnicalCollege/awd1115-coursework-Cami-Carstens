
using Project8;

Cart cart1 = new Cart("CART1234");

cart1.AddItem("Laptop", 999.99);
cart1.AddItem("Mouse", 25.50);
cart1.AddItem("Keyboard", 45.00);
cart1.AddItem("Monitor", 150.75);
cart1.AddItem("USB Cable", 10.00);
cart1.DisplayCart();


cart1.RemoveItem("Mouse");
cart1.DisplayCart();


Cart cart2 = new Cart("CART5678");
cart2.AddItem("Smartphone", 799.99);
cart2.AddItem("Earbuds", 59.99);
cart2.AddItem("Charger", 19.99);
cart2.DisplayCart();


cart2.RemoveItem("Charger");
cart2.DisplayCart();
