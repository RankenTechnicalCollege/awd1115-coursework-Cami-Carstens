using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace CH06.Models
{
    public class FaqsContext: DbContext
    {
        public FaqsContext(DbContextOptions<FaqsContext> options) : base(options) { }

        public DbSet<FAQ> FAQs { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = "gen",
                    Name = "General"
                },
                new Category
                {
                    CategoryId = "hist",
                    Name = "History"

                });

            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    TopicId = "asp",
                    Name = "ASP.NET Core"
                },
                new Topic
                {
                    TopicId = "blz",
                    Name = "Blazor",
                },
                new Topic
                {
                    TopicId = "ef",
                    Name = "Entity Framework"
                });

            modelBuilder.Entity<FAQ>().HasData(
                new FAQ
                {
                    FAQId = 1,
                    Question = "What is ASP.NET Core?",
                    Answer = "ASP.NET Core is a free and open-sourced, cross-platform framework developed by Microsoft for building web applications and services.",
                    CategoryId = "gen",
                    TopicId = "asp"
                },
                new FAQ
                {
                    FAQId = 2,
                    Question = "When was ASP.NET Core released?",
                    Answer = "ASP?NET Core 1.0 was released on June 27, 2016",
                    CategoryId = "hist",
                    TopicId = "asp"
                },
                new FAQ
                {
                    FAQId = 3,
                    Question = "What is Blazor?",
                    Answer = "Blazor is an open-source, cross-platform web framework developed by Microsoft that enables developers to build interactive client-side web UIs using C# and .NET instead of JavaScript. It allows for the creation of modern web applications using a component-based model, similar to frameworks like React or Angular, but leveraging the .NET ecosystem.",
                    CategoryId = "gen",
                    TopicId = "blz"
                },
                new FAQ
                {
                    FAQId = 4,
                    Question = "When was Blazor released?",
                    Answer = "Blazor was released on May 14, 2020",
                    CategoryId = "hist",
                    TopicId = "blz"
                },
                  new FAQ
                  {
                      FAQId = 5,
                      Question = "What is Entity Framework?",
                      Answer = "Entity Framework is an open-source ORM framework for .NET applications supported by Microsoft. It enables developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns where this data is stored.",
                      CategoryId = "gen",
                      TopicId = "ef"
                  },
                    new FAQ
                    {
                        FAQId = 6,
                        Question = "When was Entity Framework released?",
                        Answer = "Entity Framework 1.0 was released in 2008",
                        CategoryId = "hist",
                        TopicId = "ef"
                    });
        }
    }
}
