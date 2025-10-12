using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOT3.Migrations
{
    /// <inheritdoc />
    public partial class addcategorytohoodie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageFileName",
                value: "classic-hoodie.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageFileName",
                value: "classic.hoodie.jpg");
        }
    }
}
