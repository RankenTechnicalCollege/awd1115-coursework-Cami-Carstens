namespace HOT3.Models
{
    public class ShoppingCartViewModel
    {
        //1 to many relationship
        public List<ShoppingCartItem> CartItems { get; set; } 
        public decimal? TotalPrice { get; set; }
        public int? TotalQuantity { get; set; }
    }
}
