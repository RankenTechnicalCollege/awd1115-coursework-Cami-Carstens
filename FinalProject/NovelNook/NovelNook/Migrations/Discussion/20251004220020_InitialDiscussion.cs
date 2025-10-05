using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNook.Migrations.Discussion
{
    /// <inheritdoc />
    public partial class InitialDiscussion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpinionField = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Review = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Author", "Genre", "OpinionField", "Review", "Title" },
                values: new object[] { 1, "Leslye Walton", "Fiction", "The writing is so beautiful. I found myself getting emotional while reading. The story is so incredibly atmospheric and moody. You will smile and have your heart broken in the same sentence. It really is a strange and beautiful book as the title suggest. It is about the painful and beautiful aspect of humanity we all must walk.", 5, "The Strange and Beautiful Sorrows of Ava Lavender" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discussions");
        }
    }
}
