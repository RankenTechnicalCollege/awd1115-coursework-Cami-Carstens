using EmployeeValidation.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeValidation.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Please enter a first name")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name")]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Please enter date of birth")]
        [PastDate(ErrorMessage ="Date of birth must be a valid date in the past")]
        [Remote("CheckEmployee", "Validation", AdditionalFields ="FirstName, LastName")]
        [Display(Name ="Date of birth")]
        public DateTime? DOB {  get; set; }

        [Required(ErrorMessage ="Please enter date of hire")]
        [PastDate(ErrorMessage = "Date of hire must be a valid date in the past")]
        [GreaterThan("1/1/1995", ErrorMessage ="Hire date can not be before company was founded in 1995")]
        [Display(Name = "Hire Date")]
        public DateTime? DateOfHire { get; set; }

        [Display(Name ="Manager")]
        [Remote("CheckManager", "Validation", AdditionalFields ="FirstName,LastName, DOB" )]
        [GreaterThan(0, ErrorMessage ="Please select a manager")]
        public int ManagerId { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
