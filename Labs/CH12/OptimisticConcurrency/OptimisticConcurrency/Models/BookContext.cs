using Microsoft.EntityFrameworkCore;

namespace OptimisticConcurrency.Models
{
    public class BookContext :DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) :base(options) { }
        public DbSet<Book> Books { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                { 
                    BookId = 1, 
                    Title = "The Great Gatsby", 
                    Author = "F. Scott Fitzgerald", 
                    Price = 10.99 
                },
                new Book
                { 
                    BookId = 2, 
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee", 
                    Price = 12.99 
                },
                new Book 
                { 
                    BookId = 3, 
                    Title = "1984", 
                    Author = "George Orwell", 
                    Price = 14.99 }
            );
        }
    }
}
