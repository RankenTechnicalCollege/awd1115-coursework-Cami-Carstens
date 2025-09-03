using System.ComponentModel.DataAnnotations;

namespace Project2_1.Models
{
    public class Calculate
    {
        [Required(ErrorMessage = "Invalid entry. Meal cost is required for calculation.")]
        [Range(1, 10000, ErrorMessage = "Invalid entry. Meal cost must be between 1.00 and 10,000.00.")]
        public decimal BillAmount { get; set; }

        //15%, 20% and 25%
        public decimal Tip15()
        {
            return BillAmount * 0.15m;
        }
        public decimal Tip20()
        {
            return BillAmount * 0.20m;
        }
        public decimal Tip25()
        {
            return BillAmount * 0.25m;
        }

        public decimal TotalAmount(decimal tipAmount)
        {
            return BillAmount + tipAmount;
        }




    }
}
