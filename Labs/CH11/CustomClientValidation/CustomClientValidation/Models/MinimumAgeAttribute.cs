using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CustomClientValidation.Models
{

    
    public class MinimumAgeAttribute :ValidationAttribute, IClientModelValidator
    {
        private int minYears;
        public MinimumAgeAttribute(int years)
        {
            minYears = years;
        }

        public void AddValidation(ClientModelValidationContext ctx)
        {
            //client side
            if (!ctx.Attributes.ContainsKey("data-val"))
                ctx.Attributes.Add("data-val", "true");
            ctx.Attributes.Add("data-val-minimumagee-years",
                minYears.ToString());
            ctx.Attributes.Add("data-val-minimumage",
                GetMsg(ctx.ModelMetadata.DisplayName ?? ctx.ModelMetadata.Name ?? "Date"));
        }

        protected override ValidationResult IsValid(object? value, ValidationContext ctx)
        {
            if(value is DateTime)
            {
                //convert value passed in to a DateTime object 
                DateTime dateToCheck = (DateTime)value;

                //now the value passed in is called dateToCheck & compare it to minYears
                dateToCheck = dateToCheck.AddYears(minYears);
                //is it less than today? 
                if(dateToCheck <= DateTime.Today)
                {
                    return ValidationResult.Success!;
                }
            }
            return new ValidationResult(GetMsg(ctx.DisplayName ?? "Date"));
        }
        private string GetMsg(string name)=>
        
            base.ErrorMessage ?? $"{name} must be at least {minYears} years ago";
        
            
    }
}
