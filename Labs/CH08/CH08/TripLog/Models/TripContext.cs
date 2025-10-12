using Microsoft.EntityFrameworkCore;
using TripLog.Models;

namespace TripLog.Models
{
    public class TripContext(DbContextOptions<TripContext> options) :DbContext(options)
    {
        public DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<Trip>().HasData(
                new Trip 
                { 
                    TripLogId = 1,
                    StartDate = new DateOnly(2023, 1, 15),
                    EndDate = new DateOnly(2023, 1, 21),
                    Destination = "Hawaii",
                    Accommodation = "Royal Kona Resort",
                    AccommodationEmail = "Royal_Kona@gmail.com",
                    AccommodationPhone = "808-555-1234",
                    Activity1 = "See the Thurston Lava Tube",
                    Activity2 = "Snorkeling at Kealakekua Bay",
                    Activity3 = "Visit the Pu'uhonua o Honaunau National Historical Park",
                   
                },
                new Trip 
                { 
                    TripLogId = 2,
                    StartDate = new DateOnly(2023, 2, 20),
                    EndDate = new DateOnly(2023, 1, 21),
                    Destination = "Portland Oregon",
                    Accommodation = "Lorelei Bed & Breakfast",
                    AccommodationEmail = "Lorelei_B&B_tripinfo.com",
                    AccommodationPhone = "503-555-5678",
                    Activity1 = "Japanese Garden",
                    Activity2="Portland Science Museum",
                    Activity3="Powell City of Books ",
                   
                 
                },
                new Trip 
                { 
                    TripLogId = 3,
                    StartDate = new DateOnly(2027, 3, 25),
                    EndDate = new DateOnly(2027, 4, 21),
                    Destination = " Sarasota Florida",
                    Accommodation = "Holiday Inn",
                    AccommodationEmail = "Holiday-InnBESTNIGHTSLEEP@info.org",
                    AccommodationPhone = "941-555-9876",
                   Activity1 = "Beach day",
                   Activity2 = "Swimming with dolphins",
                   Activity3 = "Disney World",
               
                },
                new Trip
                {
                    TripLogId = 4,
                    StartDate = new DateOnly(2026, 12, 16),
                    EndDate = new DateOnly(2026, 12, 30),
                    Destination = "Branson Missouri",
                    Accommodation = "Lodge of the Ozarks",
                    AccommodationEmail = "The_Lodge@ozarks.com",
                    AccommodationPhone = "417-555-2468",
                    Activity1 = "Silver Dollar City",
                    Activity2 = "Christmas Lights", 
                    Activity3 = "Castle Rock Indoor WaterPark",
                   
                }
            );
        }

    }
}
