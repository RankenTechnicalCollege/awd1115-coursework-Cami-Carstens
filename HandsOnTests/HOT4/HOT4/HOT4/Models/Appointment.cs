using HOT4.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace HOT4.Models
{

    [NoDoubleBookingCheck(ErrorMessage ="This appointment slot is already booked. Please choose another date/time")]
    public class Appointment
    {
        [Required(ErrorMessage = "Id is required")]
        public int AppointmentId { get; set; }


        [Required(ErrorMessage = "Appointment date and time is required")]
        [FutureDate(ErrorMessage = "Appointments must be scheduled in the future")]
        [Display(Name ="Appointment Date")]
        public DateTime AppDate { get; set; }


        [HourAppOnly(ErrorMessage = "Appointments must be made on the hour")]
        [Display(Name ="Appointment Time")]
        public TimeSpan AppTime { get; set; }


        [Required(ErrorMessage ="Please enter username")]
        public string Username { get; set; } = null!;


        [Required(ErrorMessage ="Phone number must be in the format xxx-xxx-xxxx")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage ="Phone number must be in format xxx-xxx-xxxx")]
         public string PhoneNumber { get; set; } = null!;


        //FK
        public int CustomerId { get; set; }

        //nav prop to Customer table
        public Customer? Customer { get; set; } 
        public string Slug => $"{Username?.ToLower()}".Replace(" ", "-");
    }
}
