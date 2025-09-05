using System.ComponentModel.DataAnnotations;

namespace Project2_1.Models
{
    public class Calculate
    {
        [Required(ErrorMessage = "Please enter meal cost.")]
        [Range(1, 5000, ErrorMessage = "Please enter cost of meal.")]
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
