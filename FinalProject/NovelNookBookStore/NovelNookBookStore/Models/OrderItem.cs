using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public int BookId { get; set; }
        public int DecorId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
 
    }
}
