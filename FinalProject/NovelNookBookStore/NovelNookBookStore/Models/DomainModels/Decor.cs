using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelNookBookStore.Models.DomainModels
{
    public class Decor
    {
        public int DecorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? Image { get; set; } = null!;

        public string? LinkUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<OrderItem>? OrderItems
        {
            get; set;
        }
        //[ValidateNever]
        //public ICollection<DecorReview> DecorReviews { get; set; } = new List<DecorReview>();

        //for AddEdit image file uploading 
     

        [NotMapped]
        [ValidateNever]
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl
        {
            get; set;
        }
    }
}
