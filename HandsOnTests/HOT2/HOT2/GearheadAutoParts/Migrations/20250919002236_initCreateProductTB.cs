using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GearheadAutoParts.Migrations
{
    /// <inheritdoc />
    public partial class initCreateProductTB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescLong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "ProductDescLong", "ProductDescShort", "ProductImage", "ProductName", "ProductPrice", "ProductQty" },
                values: new object[,]
                {
                    { 1, 1, "This spark plug is designed to provide a strong and consistent spark, ensuring efficient combustion and improved engine performance. It features a durable construction and is suitable for a wide range of vehicles.", "High-performance spark plug for optimal ignition.", "", "Spark Plug", 14.99m, 150m },
                    { 2, 2, "These brake pads are made from high-quality materials to ensure long-lasting performance and safety. They provide excellent friction and heat resistance, making them ideal for both everyday driving and high-performance applications.", "Durable brake pads for reliable stopping power.", "", "Brake Pads", 49.99m, 80m },
                    { 3, 3, "This shock absorber is engineered to absorb road vibrations and impacts, providing a comfortable and stable driving experience. It features advanced damping technology and is compatible with various vehicle models.", "Premium shock absorber for a smooth ride.", "", "Shock Absorber", 89.99m, 60m },
                    { 4, 4, "This alternator is designed to efficiently convert mechanical energy into electrical energy, ensuring a steady power supply to your vehicle's electrical systems. It features a robust design and is built to last.", "Reliable alternator for consistent power supply.", "", "Alternator", 199.99m, 40m },
                    { 5, 5, "This exhaust muffler is designed to reduce engine noise while maintaining optimal exhaust flow. It features a durable construction and is suitable for a variety of vehicle types, enhancing both performance and sound quality.", "High-quality exhaust muffler for noise reduction.", "", "Exhaust Muffler", 129.99m, 70m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
