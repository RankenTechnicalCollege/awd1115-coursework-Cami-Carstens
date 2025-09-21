using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GearheadAutoParts.Migrations
{
    /// <inheritdoc />
    public partial class makeOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "This spark plug is designed to provide a strong and consistent spark, ensuring efficient combustion and improved engine performance. It features a durable construction and is suitable for a wide range of vehicles.", "High-performance spark plug for optimal ignition." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "These brake pads are made from high-quality materials to ensure long-lasting performance and safety. They provide excellent friction and heat resistance, making them ideal for both everyday driving and high-performance applications.", "Durable brake pads for reliable stopping power." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "This shock absorber is engineered to absorb road vibrations and impacts, providing a comfortable and stable driving experience. It features advanced damping technology and is compatible with various vehicle models.", "Premium shock absorber for a smooth ride." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "This alternator is designed to efficiently convert mechanical energy into electrical energy, ensuring a steady power supply to your vehicle's electrical systems. It features a robust design and is built to last.", "Reliable alternator for consistent power supply." });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "ProductDescLong", "ProductDescShort" },
                values: new object[] { "This exhaust muffler is designed to reduce engine noise while maintaining optimal exhaust flow. It features a durable construction and is suitable for a variety of vehicle types, enhancing both performance and sound quality.", "High-quality exhaust muffler for noise reduction." });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }
    }
}
