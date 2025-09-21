using Microsoft.EntityFrameworkCore;
namespace GearheadAutoParts.Models
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {

        }
     
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        // Seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-to-One
            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithOne(c => c.Product)
                .HasForeignKey<Product>(p => p.CategoryId);


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Ignition System" },
                new Category { CategoryId = 2, CategoryName = "Braking System" },
                new Category { CategoryId = 3, CategoryName = "Suspension System" },
                new Category { CategoryId = 4, CategoryName = "Electrical System" },
                new Category { CategoryId = 5, CategoryName = "Exhaust System" }
                );

            modelBuilder.Entity<Product>().HasData(

                new Product
                {
                    ProductId = 1,
                    ProductName = "Spark Plug",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 14.99m,
                    ProductQty = 150,
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Brake Pads",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 49.99m,
                    ProductQty = 80,
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Shock Absorber",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 89.99m,
                    ProductQty = 60,
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Alternator",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 199.99m,
                    ProductQty = 40,
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Exhaust Muffler",
                    ProductDescShort = "",
                    ProductDescLong = "",
                    ProductImage = "",
                    ProductPrice = 129.99m,
                    ProductQty = 70,
                    CategoryId = 5
                }
                );

            }
        }

    }

    
