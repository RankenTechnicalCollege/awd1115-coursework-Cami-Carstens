using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Models
{
    public class Bike
    {
        public int BikeId { get; set; }
        [Required(ErrorMessage = "Please enter a manufacturer")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Must be between 3 and 60 characters")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "Please enter a model")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Must be between 3 and 60 characters")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter a year ")]
        [Range(1900, 2100, ErrorMessage = "Must be between 1900 and 2100")]
        public string Year { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18. 2)")]
        [Range(1, 30000, ErrorMessage = "Please enter a price between 1 and 30,000")]
        [Required(ErrorMessage = "Please enter a price")]
        public decimal? Price { get; set; }
        [Required]
        public DateOnly CreatedOn { get; set; }
        [Required]
        [Range(1,5)]
        public double Rating { get; set; }


    }


}
