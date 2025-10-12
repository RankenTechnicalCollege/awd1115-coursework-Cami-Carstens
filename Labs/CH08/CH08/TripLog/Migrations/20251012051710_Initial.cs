using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripLog.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TripLogs",
                table: "TripLogs");

            migrationBuilder.RenameTable(
                name: "TripLogs",
                newName: "Trips");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trips",
                table: "Trips",
                column: "TripLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Trips",
                table: "Trips");

            migrationBuilder.RenameTable(
                name: "Trips",
                newName: "TripLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripLogs",
                table: "TripLogs",
                column: "TripLogId");
        }
    }
}
