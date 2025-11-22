using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelNookBookStore.Models.DomainModels
{
    public class Book
    {
       
        public int BookId { get; set; } //PK
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; } = null!;
        public string? LinkUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; } //FK
        [ValidateNever]
        public Category Category { get; set; }

        //[ValidateNever]
        //public ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

        ////for AddEdit image file uploading 
       

        [NotMapped]
        [ValidateNever]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsOnSale { get; set; }
    }
}
