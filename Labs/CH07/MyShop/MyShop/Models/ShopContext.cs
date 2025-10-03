using Microsoft.EntityFrameworkCore;

namespace MyShop.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Bicycle> Bicycles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bicycle>().HasData(
                new Bicycle
                {
                    Id = 1,
                    Brand = "Trek",
                    Model = "FX 1 Gen 4",
                    Year= 2022,
                    Type = "Hybrid",
                    Price = 699.99m,
                    Color ="Black",
                    ImageFileName = "favicon.ico"
                },
                new Bicycle
                {
                    Id = 2,
                    Brand= "Giant",
                    Model = "TCR Advanced Pro 1 Disc",
                    Year= 2023,
                    Type="Road",
                    Price = 3500.00m,
                    Color="Red",
                    ImageFileName = "giant-escape-3.jpg"

                },
                new Bicycle
                {
                    Id = 3,
                    Brand = "Specialized",
                    Model = "Rockhopper Expert 29",
                    Year = 2022,
                    Type = "Mountain",
                    Price = 1100.00m,
                    Color = "Navy Blue",
                    ImageFileName = "specialized-rockhopper.jpg"
                },
                new Bicycle
                {
                    Id = 4,
                    Brand = "Cannondale",
                    Model = "Synapse Carbon 105",
                    Year = 2024,
                    Type = "Road",
                    Price = 2500.00m,
                    Color = "Slate Gray",
                    ImageFileName = "cannondale-synapse.jpg"

                },
                new Bicycle
                {
                    Id = 5,
                    Brand = "Schwinn",
                    Model = "Streamdale 7 Speed Bike",
                    Year = 2020,
                    Type = "Road",
                    Price = 350.00m,
                    Color = "Baby Blue",
                    ImageFileName = "schwinn-streamdale.jpg"
                },
                new Bicycle
                {
                    Id = 6,
                    Brand = "Giant",
                    Model = "Escape 3",
                    Year = 2025,
                    Type = "Speed",
                    Price = 1500.00m,
                    Color = "Red",
                    ImageFileName = "giant-escape-3.jpg"
                }, 
                new Bicycle
                {
                    Id = 7,
                    Brand = "Specialized",
                    Model = "S-Works Turbo Levo 4",
                    Year = 2025,
                    Type = "Electric",
                    Price = 15399.99m,
                    Color = "Copper",
                    ImageFileName = "specialized-turbo-levo-4.jpg"
                }
                );

        }

    }
}
