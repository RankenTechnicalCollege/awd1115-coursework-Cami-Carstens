using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class DecorReview
    {
     
        public int DecorId { get; set; } 
        public int ReviewId { get; set; }
        public Decor Decor { get; set; }
        public Review Review { get; set; }
    }
}
