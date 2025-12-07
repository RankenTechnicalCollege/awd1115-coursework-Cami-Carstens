using System.ComponentModel.DataAnnotations;

namespace HOT3.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Please enter a username")]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage="Please enter a password")]
        [DataType(DataType.Password)]
        [StringLength(100)]
        public string Password { get; set; } = string.Empty;
        public string ReturnUrl { get; set; } = string.Empty;


        [Display(Name="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
