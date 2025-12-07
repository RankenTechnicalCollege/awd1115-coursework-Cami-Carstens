using System.ComponentModel.DataAnnotations;

namespace HOT3.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Please enter a username")]
        [StringLength(100)]
        public string Username { get; set; }= string.Empty;


        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
       
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string ConfirmPassword { get; set; } = null!;


    }
}
