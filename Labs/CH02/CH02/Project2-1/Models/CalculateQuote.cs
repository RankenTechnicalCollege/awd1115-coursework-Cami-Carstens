using System.ComponentModel.DataAnnotations;

namespace Project2_1.Models
{
    public class CalculateQuote
    {
        [Required(ErrorMessage = "Invalid entry.")]
        [Range(typeof(decimal), "0", "100", ErrorMessage = "Invalid entry. Quote amount must be between 1.00 and 10,000.00.")]

        public decimal Subtotal { get; set; }

        [Required(ErrorMessage = "Invalid entry.")]
        [Range(typeof(decimal),"0", "100", ErrorMessage = "Invalid entry. Discount percent must be between 0 and 100.")]
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
