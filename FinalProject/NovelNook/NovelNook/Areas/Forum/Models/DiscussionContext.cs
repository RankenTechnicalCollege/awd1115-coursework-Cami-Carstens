using Microsoft.EntityFrameworkCore;


namespace NovelNook.Areas.Forum.Models
{
    public class DiscussionContext : DbContext
    {
        public DiscussionContext(DbContextOptions<DiscussionContext> options) : base(options) { }

        public DbSet<Discussion> Discussions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discussion>().HasData(
                new Discussion
                {
                    Id = 1,
                    Author = "Leslye Walton",
                    Title = "The Strange and Beautiful Sorrows of Ava Lavender",
                    OpinionField = "The writing is so beautiful. I found myself getting emotional while reading. The story is so incredibly atmospheric and moody. You will smile and have your heart broken in the same sentence. It really is a strange and beautiful book as the title suggest. It is about the painful and beautiful aspect of humanity we all must walk.",
                    Genre = "Fiction",
                    Review = 5
                }
                );
        }
    }
}
