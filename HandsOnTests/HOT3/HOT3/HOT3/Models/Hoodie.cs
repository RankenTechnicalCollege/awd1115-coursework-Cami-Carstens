using System.ComponentModel.DataAnnotations;

namespace HOT3.Models
{
    public class Hoodie
    {
        public int Id { get; set; }
        public int HoodieId { get; set; }
        [Required(ErrorMessage = "Brand is required")]
        public string? Brand { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is required")]

        public string? Description { get; set; }
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between 0.01 and 100.00")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Color is required")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "Material is required")]
        public string? Material { get; set; }

        public string? ImageFileName { get; set; }

        public Category? Category { get; set; } // Navigation property to Category class
       public int? CategoryId { get; set; } // Foreign key to Category class



        public string Slug => $"{Name?.ToLower()}".Replace(" ", "-");
    }
}
