using System.ComponentModel.DataAnnotations;

namespace GearheadAutoParts.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; }


        public Product? Product { get; set; } = null;
        //public List<Product>? Products { get; set; }
    }
}
