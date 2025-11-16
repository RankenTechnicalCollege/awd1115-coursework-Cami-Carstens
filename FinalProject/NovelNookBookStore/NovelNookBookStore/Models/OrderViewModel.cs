using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class OrderViewModel
    {
        public decimal TotalAmount { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Decor> Decors { get; set; }
    }
}
