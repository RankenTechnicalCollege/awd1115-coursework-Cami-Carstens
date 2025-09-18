using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CH04.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Invalid email address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Phone number is required.")]
        public string? Phone { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }


        [Range(1, 4)]
        public int CategoryId { get; set; }
        public DateTime Created { get; set; }
    
    public string Slug => $"{FirstName?.ToLower()}-{LastName?.ToLower()}".Replace(" ", "-");
    }
}
