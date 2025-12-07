using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models.ViewModels
{
    public class OrderViewModel
    {
        public decimal TotalAmount { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Decor> Decors { get; set; }
        public IEnumerable<Sale> Sales { get; set; } = new List<Sale>();

        public decimal Subtotal { get; set; }
        public decimal TaxRate { get; set; } = 0.08m;
      
        public decimal TaxAmount { get; set; }
       
    }
}
