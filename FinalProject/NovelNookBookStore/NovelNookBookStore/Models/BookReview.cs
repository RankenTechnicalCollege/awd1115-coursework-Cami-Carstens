using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class BookReview
    {
        public int BookId { get; set; } //FK
        public int ReviewId { get; set; }
        public Book Book { get; set; }
        public Review Review { get; set; }
    }
}
