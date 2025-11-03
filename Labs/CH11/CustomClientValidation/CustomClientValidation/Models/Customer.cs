using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomClientValidation.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [RegularExpression("^[a-z-Z0-9 ]+$")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage ="Please enter an email address.")]
        [Display(Name = "Email Address")]
        [Remote("CheckEmail", "Validation")]
        public string EmailAddress { get; set; } = string.Empty;


        [Required(ErrorMessage ="Please enter a date of birth")]
        [Display(Name ="Date of Birth")]
        [MinimumAge(18, ErrorMessage="You must be at least 18 years old to register")]
        public DateTime? DOB { get; set; }
        [Required(ErrorMessage ="Please enter a password")]
        [Compare("ConfirmPassword")]
        [StringLength(25, ErrorMessage ="Password must be at most 25 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please confirm email address")]
        [Display(Name = "Confirm Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
