using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieProject.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Name", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, "Inception", 8, 2010 },
                    { 2, "The Dark Knight", 9, 2008 },
                    { 3, "Pulp Fiction", 7, 1994 },
                    { 4, "The Shawshank Redemption", 10, 1994 },
                    { 5, "The Godfather", 9, 1972 },
                    { 6, "The Matrix", 8, 1999 },
                    { 7, "Forrest Gump", 8, 1994 },
                    { 8, "Fight Club", 7, 1999 },
                    { 9, "Interstellar", 8, 2014 },
                    { 10, "The Lord of the Rings: The Return of the King", 9, 2003 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
