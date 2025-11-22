using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public Order? Order { get; set; }
        public int? BookId { get; set; }
        public int? DecorId { get; set; }
        public int? SaleItemId { get; set; }
        public Sale? SaleItem { get; set; }
      
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Book? Book { get; set; }
        public Decor? Decor { get; set; }


    }
}
