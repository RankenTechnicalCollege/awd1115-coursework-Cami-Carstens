using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TripLog.Models
{
    public class Trip
    {
        [Key]
        public int TripLogId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Destination { get; set; } = string.Empty;
        public string Accommodation { get; set; } = string.Empty;
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }
        public string? Activity1 { get; set; }
        public string? Activity2 { get; set; }
        public string? Activity3 { get; set; }
    }




    public class TripPage1 
        
        { 
              [Required(ErrorMessage = "Please enter a starting date for your trip.")]
        [Display(Name = "Start Date")]
        public DateOnly StartDate { get; set; }
            [Required(ErrorMessage = "Please enter an ending date for your trip.")]
            [Display(Name = "End Date")]
        public DateOnly EndDate { get; set; }
             [Required(ErrorMessage = "Please enter a destination for your trip.")]
            public string Destination { get; set; } = string.Empty;
            [Required(ErrorMessage = "Please enter your accommodation information.")]
            public string Accommodation { get; set; } = string.Empty;
        }


        public class TripPage2
        {
            [Display(Name = "Phone Number")]
            public string? AccommodationPhone { get; set; }
            [Display(Name = "Email Address")]
        public string? AccommodationEmail { get; set; }
        }
      

        public class TripPage3
        {
            public string? Activity1 { get; set; }
            public string? Activity2 { get; set; }
            public string? Activity3 { get; set; }
        }
    
    }

