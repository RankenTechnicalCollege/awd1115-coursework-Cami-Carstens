using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string? OpinionField { get; set; }


        public int? BookId { get; set; } //FK to Book
        public Book? Book { get; set; }

        public int? DecorId { get; set; } //FK to Decor
        public Decor? Decor { get; set; }

        //public ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();
        //public ICollection<DecorReview> DecorReviews { get; set; } = new List<DecorReview>();
    }
}
