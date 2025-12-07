using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNookBookStore.Migrations
{
    /// <inheritdoc />
    public partial class addClearance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "ImageUrl",
                value: "/Images/Book-Thumb2.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "SaleId",
                keyValue: 6,
                column: "ImageUrl",
                value: "Images/Book-Thumb.jpg");
        }
    }
}
