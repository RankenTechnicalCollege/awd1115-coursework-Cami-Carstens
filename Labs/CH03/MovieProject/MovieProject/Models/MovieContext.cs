//allows you to inherit from DbContext
using Microsoft.EntityFrameworkCore;


namespace MovieProject.Models
{
    public class MovieContext : DbContext
    {
        //DbSet<MovieModel>(movie list from database) Movies property represents the collection of MovieModel objects
        //Property to store list of movies
        public DbSet<MovieModel> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;

        //Constructor that takes DbContextOptions<MovieContext> options as a parameter and passes it to the base DbContext constructor
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "A", Name = "Action" },
                new Genre { GenreId = "C", Name = "Comedy" },
                new Genre { GenreId = "D", Name = "Drama" },
                new Genre { GenreId = "H", Name = "Horror" },
                new Genre { GenreId = "SF", Name = "Sci-Fi" },
                new Genre { GenreId = "R", Name = "Romance" },
                new Genre { GenreId = "T", Name = "Thriller" },
                new Genre { GenreId = "F", Name = "Fantasy" }
               
            );



            modelBuilder.Entity<MovieModel>().HasData(
                new MovieModel
                {
                    MovieId = 1,
                    Name = "Inception",
                    Year = 2010,
                    Rating= 8,
                    GenreId = "SF"
                },
                new MovieModel
                {
                    MovieId = 2,
                    Name = "The Dark Knight",
                    Year = 2008,
                    Rating = 9,
                    GenreId = "A"
                },
                new MovieModel
                {
                    MovieId = 3,
                    Name = "Pulp Fiction",
                    Year = 1994,
                    Rating = 7,
                    GenreId = "T"
                },
                new MovieModel
                {
                    MovieId = 4,
                    Name = "The Shawshank Redemption",
                    Year = 1994,
                    Rating = 10,
                    GenreId = "D"
                },
                new MovieModel
                {
                    MovieId = 5,
                    Name = "The Godfather",
                    Year = 1972,
                    Rating = 9,
                    GenreId = "D"
                },
                new MovieModel
                {
                    MovieId = 6,
                    Name = "The Matrix",
                    Year = 1999,
                    Rating = 8,
                    GenreId = "SF"
                },
                new MovieModel
                {
                    MovieId = 7,
                    Name = "Forrest Gump",
                    Year = 1994,
                    Rating = 8,
                    GenreId = "R"
                },
                new MovieModel
                {
                    MovieId = 8,
                    Name = "Fight Club",
                    Year = 1999,
                    Rating = 7,
                    GenreId = "D"
                },
                new MovieModel
                {
                    MovieId = 9,
                    Name = "Interstellar",
                    Year = 2014,
                    Rating = 8,
                    GenreId = "SF"
                },
                new MovieModel
                {
                    MovieId = 10,
                    Name = "The Lord of the Rings: The Return of the King",
                    Year = 2003,
                    Rating = 9,
                    GenreId = "F"
                },
                new MovieModel
                {
                    MovieId = 11,
                    Name = "The Avengers",
                    Year = 2012,
                    Rating = 7,
                    GenreId = "A"
                },
                new MovieModel
                {
                    MovieId = 12,
                    Name = "Gladiator",
                    Year = 2000,
                    Rating = 8,
                    GenreId = "A"
                },
                new MovieModel
                {
                    MovieId = 13,
                    Name = "SuperBabies: Baby Geniuses 2",
                    Year = 2004,
                    Rating = 1,
                    GenreId = "C"
                },
                new MovieModel
                {
                    MovieId = 14,
                    Name = "Cats",
                    Year = 2019,
                    Rating = 2,
                    GenreId = "C"
                },
                new MovieModel
                {
                    MovieId = 15,
                    Name = "Disaster Movie",
                    Year = 2008,
                    Rating = 1,
                    GenreId = "C"
                }
            );
        }
        
    
}
}

