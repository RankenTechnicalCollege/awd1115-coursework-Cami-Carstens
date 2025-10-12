namespace HOT3.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Hoodie? Hoodie { get; set; }
        public int Quantity { get; set; }
    }
}
