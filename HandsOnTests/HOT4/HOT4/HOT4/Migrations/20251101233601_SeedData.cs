using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOT4.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppDate", "AppTime", "CustomerId", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 15, 0, 0, 0), 5, "314-987-6543", "SandySue" },
                    { 2, new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 2, "314-299-0321", "JackieC999" },
                    { 3, new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 13, 0, 0, 0), 3, "618-407-6555", "DarylD4321" },
                    { 4, new DateTime(2025, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), 1, "314-495-7733", "ThomasRoad123" },
                    { 5, new DateTime(2026, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 14, 0, 0, 0), 5, "314-987-6543", "SandySue" },
                    { 6, new DateTime(2025, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), 4, "636-333-3210", "FrancisDay1" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "314-495-7733", "ThomasRoad123" },
                    { 2, "314-299-0321", "JackieC999" },
                    { 3, "618-407-6555", "DarylD4321" },
                    { 4, "636-333-3210", "FrancisDay1" },
                    { 5, "314-987-6543", "SandySue" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
