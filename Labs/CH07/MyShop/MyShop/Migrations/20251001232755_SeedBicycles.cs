using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedBicycles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Bicycles",
                columns: new[] { "Id", "Brand", "Color", "ImageFileName", "Model", "Price", "Type", "Year" },
                values: new object[,]
                {
                    { 1, "Trek", "Black", "favicon.ico", "FX 1 Gen 4", 699.99m, "Hybrid", 2022 },
                    { 2, "Giant", "Red", "giant-escape-3.jpg", "TCR Advanced Pro 1 Disc", 3500.00m, "Road", 2023 },
                    { 3, "Specialized", "Navy Blue", "specialized-rockhopper.jpg", "Rockhopper Expert 29", 1100.00m, "Mountain", 2022 },
                    { 4, "Cannondale", "Slate Gray", "cannondale-synapse.jpg", "Synapse Carbon 105", 2500.00m, "Road", 2024 },
                    { 5, "Schwinn", "Baby Blue", "schwinn-streamdale.jpg", "Streamdale 7 Speed Bike", 350.00m, "Road", 2020 },
                    { 6, "Giant", "Red", "giant-escape-3.jpg", "Escape 3", 1500.00m, "Speed", 2025 },
                    { 7, "Specialized", "Copper", "specialized-turbo-levo-4.jpg", "S-Works Turbo Levo 4", 15399.99m, "Electric", 2025 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bicycles");
        }
    }
}
