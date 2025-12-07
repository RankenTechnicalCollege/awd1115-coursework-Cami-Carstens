namespace NovelNookBookStore.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int? BookId { get; set; }
        public string? BookTitle { get; set; }
        public int? DecorId { get; set; }
        public string? DecorName { get; set; }
     
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? SaleItemId { get; set; }
        public string? SaleItemName { get; set; }

    }
}