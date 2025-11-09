using System.ComponentModel.DataAnnotations;

namespace OptimisticConcurrency.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public double Price { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; } = null!;  //required for optimistic concurrency, byte[] data type required
    }
}

