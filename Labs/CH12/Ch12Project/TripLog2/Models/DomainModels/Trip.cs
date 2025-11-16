using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripLog2.Models.DomainModels
{
    public class Trip
    {
        public Trip() => Activities = new HashSet<Activity>();
        public int TripId { get; set; }


        [NotMapped]
        [Required(ErrorMessage = "Please enter a destination.")]
        public string? DestinationName { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please enter an accommodation.")]
        public string? AccommodationName { get; set; }

        public int DestinationId { get; set; } //fk
        [ValidateNever]
        public Destination Destination { get; set; } = null!; //nav prop

        [Required(ErrorMessage = "Please enter the date your trip starts.")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "Please enter the date your trip ends.")]
        public DateTime? EndDate { get; set; }

        public int AccommodationId { get; set; } //fk
        [ValidateNever]
        public Accommodation? Accommodation { get; set; } = null!; //nav prop

       //skip nav prop
       public ICollection<Activity> Activities { get; set; } 
    }
}
