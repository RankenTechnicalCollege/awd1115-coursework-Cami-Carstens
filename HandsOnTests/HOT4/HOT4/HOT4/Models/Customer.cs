using System.ComponentModel.DataAnnotations;

namespace HOT4.Models
{
    public class Customer
    {
        [Required(ErrorMessage ="Customer Id is required")]
        public int CustomerId { get; set; }


        [Required(ErrorMessage ="Customer username is required")]
        public string Username { get; set; } = string.Empty;


        [Required(ErrorMessage ="A valid customer phone number is required")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must be in format xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Slug => $"{Username?.ToLower()}".Replace(" ", "-");
    }
}
