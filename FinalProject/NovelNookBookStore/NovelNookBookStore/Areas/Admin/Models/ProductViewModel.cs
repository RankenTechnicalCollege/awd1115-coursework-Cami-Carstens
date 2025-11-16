using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public string Type { get; set; } //is it a book or decor?
        public int Id { get; set; }

        public Book? Book { get; set; }
        public Decor? Decor { get; set; }

        public static ProductViewModel FromBook(Book b) =>
            new ProductViewModel
            {
                Type = "Book",
                Id = b.BookId,
                Book = b
            };
        public static ProductViewModel FromDecor(Decor d) =>
            new ProductViewModel
            {
                Type = "Decor",
                Id = d.DecorId,
                Decor = d
            };
    }
}
