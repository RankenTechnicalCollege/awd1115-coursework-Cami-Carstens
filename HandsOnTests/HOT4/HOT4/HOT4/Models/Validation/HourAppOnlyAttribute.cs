using System.ComponentModel.DataAnnotations;

namespace HOT4.Models.Validation
{
    public class HourAppOnlyAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            if(value is TimeSpan ts)
            {
                if (ts.Minutes != 0 || ts.Seconds != 0)
                    return new ValidationResult(ErrorMessage ?? "Appointments must be made on the hour.");
            }
            return ValidationResult.Success;
        }
    }
}
