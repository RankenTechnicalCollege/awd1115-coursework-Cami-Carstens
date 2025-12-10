using NovelNookBookStore.Data;
using System.ComponentModel.DataAnnotations;

namespace NovelNookBookStore.Models.Validation
{
    public class UniqueDecorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            string name = value.ToString() ?? string.Empty;
            var dbContext = (ApplicationDbContext)context.GetService(typeof(ApplicationDbContext))!;

            bool exists = dbContext.Decors.Any(d => d.Name.ToLower() == name.ToLower());
            if(exists)
            {
                return new ValidationResult("A decor with this name already exists.");
            }
            return ValidationResult.Success;
        }
    }
}
