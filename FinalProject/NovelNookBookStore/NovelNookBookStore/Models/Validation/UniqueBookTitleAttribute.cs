using NovelNookBookStore.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace NovelNookBookStore.Models.Validation
{
    public class UniqueBookTitleAttribute : ValidationAttribute
    {
       protected override ValidationResult? IsValid(object? value,ValidationContext context)
        {

            if(value == null)
            {
                return ValidationResult.Success;
            }
            string title = value.ToString() ?? string.Empty;

            var dbContext = (ApplicationDbContext)context.GetService(typeof(ApplicationDbContext))!;
          bool exists = dbContext.Books.Any(b => b.Title.ToLower() == title.ToLower());
            if (exists)
            {
                return new ValidationResult("A book with this title already exists.");
            }
            return ValidationResult.Success;

        }
    }
}
