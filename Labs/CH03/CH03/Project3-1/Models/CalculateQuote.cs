using System.ComponentModel.DataAnnotations;

namespace Project3_1.Models
{
    public class CalculateQuote
    {
        [Required(ErrorMessage = "Invalid entry.")]
        [Range(typeof(decimal), "0.01", "10000", ErrorMessage = "Please enter a sale price.")]

        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Invalid entry.")]
        [Range(typeof(decimal), "0.01", "100", ErrorMessage = "Please enter a discount percent.")]
        public decimal DiscountPercent { get; set; }

        public decimal DiscountAmount()
        {
            return Subtotal * (DiscountPercent / 100);
        }
        public decimal Total()
        {
            return Subtotal - DiscountAmount();
        }
    }
}
