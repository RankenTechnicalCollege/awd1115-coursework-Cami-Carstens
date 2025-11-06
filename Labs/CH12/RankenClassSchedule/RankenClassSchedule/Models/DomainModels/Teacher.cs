using System.ComponentModel.DataAnnotations;

namespace RankenClassSchedule.Models.DomainModels
{
    public class Teacher
    {
        //when i construct a teacher object, initialize our classes as a new HashSet(unique/no duplicate keys) 
        public Teacher() => Classes = new HashSet<Class>();
        public int TeacherId {get; set;}

        [Display(Name = "First Name")]
        [StringLength(100, ErrorMessage ="First name must not exceed 100 characters")]
        [Required(ErrorMessage ="Please enter a first name")]
        public string FirstName {get;set;} = string.Empty;

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last name must not exceed 100 characters")]
        [Required(ErrorMessage = "Please enter a last name")]
        public string LastName {get;set;} = string.Empty;

        //read only to bring and display first and last name together.
        public string FullName => $"{FirstName} {LastName}";

        //collection of classes with ICollection--Nav prop
        public ICollection<Class> Classes {get; set;}
    }
}
