using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CH04.Migrations
{
    /// <inheritdoc />
    public partial class InitCreateNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friend" },
                    { 3, "Work" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CategoryId", "Created", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { -6, 1, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brown.T_657@gmail.com", "Terrance", "Brown", "314-665-6789" },
                    { -5, 3, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TJ9876@gmail.com", "Thomas", "Jones", "314-891-4321" },
                    { -4, 4, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "TJones78@gmail.com", "Talia", "Jones", "314-891-5551" },
                    { -3, 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSmith123@gmail.com", "Synday", "Smith", "636-595-8765" },
                    { -2, 2, new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SimoneSMITH@yahoo.com", "Simone", "Smith", "573-555-5678" },
                    { -1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DallyJ@gmail.com", "John", "Dally", "314-555-1234" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CategoryId",
                table: "Contacts",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
