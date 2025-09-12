using HOT1.Models;
using System.ComponentModel.DataAnnotations;

namespace HOT1.Models

{
    public class Converter
    {
        [Required(ErrorMessage ="Error. Please enter inches.") ]
        [Range(0.01, 10000, ErrorMessage ="Error. Please enter inches.")]
        public double? Inches { get; set; }
        public double? Centimeters
        {
            get { return Inches * 2.54; }
        }

        public override string ToString()
        {
            return $"{Inches} inches is {Centimeters} centimeters";
        }
        
    }
}
