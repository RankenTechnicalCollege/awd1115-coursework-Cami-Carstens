using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace NovelNook.Models
{
    public class BookShelfEntry
    {
        // Primary key
        public int Id { get; set; }

        [Required(ErrorMessage="Author is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Book title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please make a reading status selection")]
        [Display(Name = "Status")]
        public string StatusMessage { get; set; } = "Future Read";

        [Required(ErrorMessage = "Please select the date")]
        [Display(Name = "Added Date")]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime AddedDate { get; set; } = DateTime.Today;

        // Navigation property-navigates to the User who placed the order
        //order has a user
        [ValidateNever]
        public IdentityUser User { get; set; }

        //Fk
        public string IdentityUserId { get; set; }
    }
}
