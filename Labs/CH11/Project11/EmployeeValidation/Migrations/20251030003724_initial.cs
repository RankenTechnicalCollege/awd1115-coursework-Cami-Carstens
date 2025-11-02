using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeValidation.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "DateOfHire", "FirstName", "LastName", "ManagerId" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jaclynn", "Reed", 0 },
                    { 2, new DateTime(1989, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel", "Davis", 1 },
                    { 3, new DateTime(1975, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angela", "Chavez", 1 },
                    { 4, new DateTime(1986, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Darius", "Mayville", 0 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[,]
                {
                    { 1, 35256.0, 1, 1, 2020 },
                    { 2, 15239.0, 2, 3, 2021 },
                    { 3, 22378.0, 3, 4, 2022 },
                    { 4, 23589.0, 4, 2, 2020 },
                    { 5, 38998.0, 1, 1, 2023 },
                    { 6, 12358.0, 4, 3, 2021 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
