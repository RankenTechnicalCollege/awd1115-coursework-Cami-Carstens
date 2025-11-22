using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelNookBookStore.Models.DomainModels
{
    public class Sale
    {
        [ValidateNever]
        public int SaleId { get; set; }
        [Display(Name ="Sale Item Name")]
        public string? SaleItemName { get; set; }

        [Display(Name= "Sale Price")]
        public decimal SalePrice { get; set; }
        [Display(Name = "Sale Item Description")]
        public string? SaleDescription
        {
            get; set;

        }

        public string? ImageUrl { get; set; }

        [NotMapped]
        [ValidateNever]
        public IFormFile? ImageFile { get; set; }
        public bool IsOnSale { get; set; }
    }
}
