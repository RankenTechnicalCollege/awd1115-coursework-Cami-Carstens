using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TripLog.Migrations
{
    /// <inheritdoc />
    public partial class tripLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripLogs",
                columns: table => new
                {
                    TripLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripLogs", x => x.TripLogId);
                });

            migrationBuilder.InsertData(
                table: "TripLogs",
                columns: new[] { "TripLogId", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Activity1", "Activity2", "Activity3", "Destination", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, "Royal Kona Resort", "Royal_Kona@gmail.com", "808-555-1234", "See the Thurston Lava Tube", "Snorkeling at Kealakekua Bay", "Visit the Pu'uhonua o Honaunau National Historical Park", "Hawaii", new DateOnly(2023, 1, 21), new DateOnly(2023, 1, 15) },
                    { 2, "Lorelei Bed & Breakfast", "Lorelei_B&B_tripinfo.com", "503-555-5678", "Japanese Garden", "Portland Science Museum", "Powell City of Books ", "Portland Oregon", new DateOnly(2023, 1, 21), new DateOnly(2023, 2, 20) },
                    { 3, "Holiday Inn", "Holiday-InnBESTNIGHTSLEEP@info.org", "941-555-9876", "Beach day", "Swimming with dolphins", "Disney World", " Sarasota Florida", new DateOnly(2027, 4, 21), new DateOnly(2027, 3, 25) },
                    { 4, "Lodge of the Ozarks", "The_Lodge@ozarks.com", "417-555-2468", "Silver Dollar City", "Christmas Lights", "Castle Rock Indoor WaterPark", "Branson Missouri", new DateOnly(2026, 12, 30), new DateOnly(2026, 12, 16) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripLogs");
        }
    }
}
