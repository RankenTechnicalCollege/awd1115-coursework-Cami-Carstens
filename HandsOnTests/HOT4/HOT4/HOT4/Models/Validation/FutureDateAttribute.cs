using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HOT4.Models.Validation
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext ctx)
        {
            if(value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;
                if(dateToCheck >DateTime.Now)
                {
                    return ValidationResult.Success!;
                }
            }
            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be a valid future date";
            return new ValidationResult(msg);
        }
    }
}
