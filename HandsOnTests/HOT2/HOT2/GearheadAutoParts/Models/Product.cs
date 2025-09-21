using System.ComponentModel.DataAnnotations;


namespace GearheadAutoParts.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [Display(Name = "Product Name")]
        public string? ProductName { get; set; }

        [Display(Name = "Short Description")]
        public string? ProductDescShort { get; set; } = null;
        [Display(Name = "Long Description")]
        public string? ProductDescLong { get; set; } = null;

        [Required(ErrorMessage = "Product Image is required")]
        [Display(Name = "Product Image")]
        public string? ProductImage { get; set; } = null;

        [Required(ErrorMessage = "Product Price is required")]
        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100,000")]
        [Display(Name = "Product Price")]
        public decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1,000")]
        [Display(Name = "Product Quantity")]
        public int? ProductQty { get; set; } 
        [Required(ErrorMessage = "Category ID is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; } 

        public Category? Category { get; set; }
        public string Slug => $"{ProductName?.ToLower()}".Replace(" ", "-");
    }
}
