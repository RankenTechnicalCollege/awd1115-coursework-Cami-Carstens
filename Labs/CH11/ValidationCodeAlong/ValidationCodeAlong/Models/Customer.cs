using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValidationCodeAlong.Utility;

namespace ValidationCodeAlong.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter username")]
                            //what is allowable
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage ="Username must not contain special characters")]
        [Remote(action:"CheckUserName", controller:"Validation")]
        public string Username { get; set; } = string.Empty;

        //[Required(ErrorMessage ="Please enter date of birth")]
        //[Range(typeof(DateTime),"1/1/1900", "1/1/2026", ErrorMessage ="Date of birth must be between 1/1/1900 and 1/1/2025" )]
        //public DateTime? DOB {  get; set; }

        [NotMapped]
        [AllowedExtenstions(new string[] {".jpg", "png", "jpeg"})]
        public IFormFile? Image {  get; set; }

        [Required(ErrorMessage ="Please enter a password")]
        [StringLength(25)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please confirm your password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; } = string.Empty;


    }
}
