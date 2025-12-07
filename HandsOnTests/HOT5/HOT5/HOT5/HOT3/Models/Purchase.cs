namespace HOT3.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int HoodieId { get; set; }//FK

        public Hoodie Hoodie { get; set; } = null!;//Navigation property
       public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        
    }
}
