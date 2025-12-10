using Microsoft.CodeAnalysis.CSharp.Syntax;
using NovelNookBookStore.Data;
using System.ComponentModel.DataAnnotations;

namespace NovelNookBookStore.Models.Validation
{
    public class UniqueSaleItemNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            string saleItemName = value.ToString() ?? string.Empty;
            var dbContext = (ApplicationDbContext)context.GetService(typeof(ApplicationDbContext))!;

            bool exists = dbContext.Sales.Any(s => s.SaleItemName.ToLower() == saleItemName.ToLower());
            if (exists)
            {
                return new ValidationResult("Sale item name must be unique.");
            }
            return ValidationResult.Success;
        }

    }
}
