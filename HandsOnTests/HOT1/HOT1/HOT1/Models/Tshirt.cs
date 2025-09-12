using System.ComponentModel.DataAnnotations;

namespace HOT1.Models
{
    public class Tshirt
    {
        [Required(ErrorMessage = "Error. Please enter a quantity.")]
        [Range(1, 1000, ErrorMessage = "Error. Please enter a quantity. Call for orders above 1,000")]
        public int? Quantity { get; set; }

        public string? DiscountCode { get; set; }
        public int? Price { get; set; }
        public decimal? SalesTax { get; set; } = 0.08m;
     
      
        public decimal? Subtotal
        {
            get
            {
                decimal? subtotal = Quantity * Price;
             
                if (DiscountCode == "6175")
                {
                    //30%
                    subtotal *= 0.70m; 
                }
                else if(DiscountCode == "1390")
                {
                    //20%
                    subtotal *= 0.80m;
                }
                else if(DiscountCode == "BB88")
                {
                    //10%
                    subtotal *= 0.90m;
                }
                    return subtotal;
            }

        }

        //Bool to check if discount code is valid
        public bool IsValidDiscountCode()
        {
          if(DiscountCode == null)
            {
                return true; //No discount code entered, so it's valid
            }
          else if(DiscountCode == "6175" || DiscountCode == "1390" || DiscountCode == "BB88")
            {
                return true; 
            }
            else
            {
                return false; 
            }
        }
        public decimal? TaxAmount
        {
            get { return Subtotal * SalesTax; }
        }

        public decimal? Total
        {
            get { return Subtotal + TaxAmount; }
        }


        public override string ToString()
        {
            return $"{Quantity}  T-Shirts @ {Price:C} each";
        }
    }
}
