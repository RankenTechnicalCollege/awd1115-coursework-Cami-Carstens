using System.ComponentModel.DataAnnotations;

namespace HOT4.Models.Validation
{
    public class NoDoubleBookingCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            var appointment = (Appointment)ctx.ObjectInstance;

            //check database
            var db = (AppointmentContext)ctx.GetService(typeof(AppointmentContext));

            bool appConflict = db.Appointments.Any(
                a => a.AppDate.Date == appointment.AppDate.Date &&
                a.AppTime == appointment.AppTime &&
                a.AppointmentId != appointment.AppointmentId);

            if (appConflict)
            {
                return new ValidationResult("This appointment time slot is already booked. Please select another slot.");
            }
            return ValidationResult.Success;
        }
    }
}
