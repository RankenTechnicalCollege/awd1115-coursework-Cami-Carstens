using System.ComponentModel.DataAnnotations;

namespace NovelNook.Areas.Forum.Models
{
    public class Discussion
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter author")]
        public string? Author { get; set; }
        [Required(ErrorMessage ="Please enter book title")]
        public string? Title {  get; set; }
        [Required(ErrorMessage ="Please choose genre")]
        public string? Genre { get; set; }
        [Required(ErrorMessage ="Form can not be empty")]
        public string? OpinionField { get; set; }
        [Required(ErrorMessage ="Please select a rating")]
        [Range(0,5)]
        public int? Review {  get; set; }

    }
}
