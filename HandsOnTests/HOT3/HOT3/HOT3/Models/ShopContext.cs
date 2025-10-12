using Microsoft.EntityFrameworkCore;

namespace HOT3.Models
{
    public class ShopContext :DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Hoodie> Hoodies { get; set; }
        public DbSet<Purchase> Purchases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seed category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    DepartmentName = "Men's"
                },
                new Category
                {
                    CategoryId = 2,
                    DepartmentName = "Women's"
                });



            modelBuilder.Entity<Hoodie>().HasData(
                new Hoodie
                {
                    Id = 1,
                    Brand= "Urban Threads",
                    Name = "Classic Hoodie",
                    Description = "A classic hoodie for everyday wear.",
                    Price = 49.99m,
                    Color = "Gray",
                    Material = "Cotton",
                    ImageFileName = "mens-classic-hoodie.jpg",
                    CategoryId = 1

                },
                new Hoodie
                {
                    Id = 2,
                    Brand = "Cozy Core",
                    Name = "Oversized Balloon Sleeved Hoodie",
                    Description = "Cozy, oversized silhouette with exaggerated balloon sleeve.",
                    Price = 59.99m,
                    Color = "Creamed Coffee",
                    Material = "Cotton and polyester blend",
                    ImageFileName = "balloon-sleeve.jpg",
                    CategoryId = 2
                },
                new Hoodie
                {
                    Id = 3,
                    Brand = "Everyday Essentials",
                    Name = "Classic Hoodie with a Boxy cut",
                    Description = "A perfectly cozy hoodie with a boxy cut.",
                    Price = 69.99m,
                    Color = "French vanilla",
                     Material = "Cotton",
                    ImageFileName = "classic-hoodie.jpg",
                    CategoryId = 1
                },
                new Hoodie
                {
                    Id = 4,
                    Brand = "Cozy Core",
                    Name = "Destroyed Hoodie",
                    Description = "A unique hoodie full of vintage character. A true lived in feeling.",
                    Price = 54.99m,
                    Color = "Destressed Black",
                    Material = "Cotton",
                    ImageFileName = "destroyed-hoodie2.jpg",
                    CategoryId = 2
                }, 
                new Hoodie
                {
                    Id = 5,
                    Brand = "Urban Threads",
                    Name = "Fleece Lined Hoodie",
                    Description = "A warm fleece hoodie for colder days. Or a curl up on the couch hoodie to keep you warm and comfy,",
                    Price = 64.99m,
                    Color = "Gray",
                    Material = "Cotten and Fleece",
                    ImageFileName = "fleece-lined-hoodie.jpg",
                    CategoryId = 1

                },
                new Hoodie
                {
                    Id = 6,
                    Brand = "Urban Threads",
                    Name = "Washed/Faded Hoodie",
                    Description = "Like your favorite hoodie you've had for years and always grab first.",
                    Color= "Washed Black",
                    Material = "Cotton",
                    Price = 44.99m,
                    ImageFileName = "faded-hoodie.jpg",
                    CategoryId = 1
                },
                new Hoodie
                {
                    Id = 7,
                    Brand = "Vintage Vibes",
                    Name = "Oversized Flower Hoodie",
                    Description = "A trendy oversized hoodie with a beautiful boho design.",
                    Price = 59.99m,
                    Color = "Multi flower",
                    Material = "Cotton Blend",
                    ImageFileName = "flower-hoodie.jpg",
                    CategoryId = 2
                },
                new Hoodie
                {
                    Id = 8,
                    Brand = "Urban Threads",
                    Name = "Boxy-Cropped Hoodie",
                    Description = "A hoodie made from sustainable materials. Designed with a cropped and boxy fit to hit you at just the perfect place. ",
                    Price = 74.99m,
                    Color = "Caramel Latte",
                    Material = "Organic Cotton and recycled polyester",
                    ImageFileName = "mens-boxy-cropped.jpg",
                    CategoryId = 1
                },
                new Hoodie
                {
                    Id = 9,
                    Brand = "Cozy Core",
                    Name = "Plus size Hoodie",
                    Description = "A hoodie with balloon sleeves, optional side splits, soft french terry lining. Oversized fit.",
                    Price = 79.99m,
                    Color = "Lavender bouqet",
                    Material = "Cotten",
                    ImageFileName = "Oversized-hoodie.jpg",
                    CategoryId = 2
                },
                new Hoodie
                {
                    Id = 10,
                    Brand = "Everyday Essentials",
                    Name = "Vintage Hoodie",
                    Description = "A hoodie with a vintage look and feel. Extra cozy. Wear on a walk, on the couch, or the grocery store.",
                    Price = 69.99m,
                    Color = "Mustard Olive",
                    Material = "Cotton and Polyester",
                    ImageFileName = "womens-cotton-hoodie.jpg",
                    CategoryId = 2
                },
                new Hoodie
                {
                    Id = 11,
                    Brand = "Vintage Vibes",
                    Name = "Cropped Hoodie",
                    Description = "A stylish cropped hoodie. With the most amazing lived in fabric feel.",
                    Price = 54.99m,
                    Color = "Red Goddess",
                    Material = "Cotton",
                    ImageFileName = "womens-cropped.jpg",
                    CategoryId = 2
                },
                new Hoodie
                {
                    Id = 12,
                    Brand = "Urban Threads",
                    Name = "Brushed vintage zip up hoodie",
                    Description = "Brushed cotton and rayon for extra softness. A washed fabric with a zip up design.",
                    Price = 79.99m,
                    Color = "Beige",
                    Material = "Cotton and rayon",
                    ImageFileName = "zip-up.jpg",
                    CategoryId = 1
                });
        }
    }
}
