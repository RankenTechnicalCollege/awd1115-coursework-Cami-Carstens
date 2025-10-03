using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Models
{
    public class Bicycle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bicycle brand is required")]
        public string? Brand { get; set; }

        [Required(ErrorMessage = "Bicycle model is required")]
        public string? Model { get; set; }
        [Required(ErrorMessage ="Bicycle year is required")]
        [Range(2000, 2025, ErrorMessage = "Year must be between 2000-2025")]
        public int Year { get; set; }

        [Required(ErrorMessage ="Bicycle type is required")]
        public string? Type { get; set; }

        [Required(ErrorMessage ="Bicycle price is required")]
        [Range(0, 30000, ErrorMessage ="Price must be 0-30000")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage ="Bicycle color is required")]
        public string? Color { get; set; }
        public string? ImageFileName { get; set; }

        public string Slug => $"{Brand}-{Model}-{Year}".ToLower().Replace(" ","-");
    }
}
