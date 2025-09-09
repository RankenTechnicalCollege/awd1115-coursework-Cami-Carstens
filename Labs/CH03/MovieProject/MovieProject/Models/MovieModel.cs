using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace MovieProject.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage ="Please enter a movie name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1900, 2025, ErrorMessage = "Year must be between 1900 and 2025 characters.")]
        public int? Year { get; set; }


        //Foreign key property
        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10 characters.")]
        public int? Rating { get; set; }

        //Read only prop for the slug
        public string Slug => Name?.Replace(' ', '-').ToLower() + "-" + Year?.ToString();


        [Required(ErrorMessage = "Please enter a genre.")]
        public string GenreId { get; set; }

        //navigation property-links the 2 table together
        [ValidateNever]
        public Genre Genre { get; set; } =null!;

    }
}
