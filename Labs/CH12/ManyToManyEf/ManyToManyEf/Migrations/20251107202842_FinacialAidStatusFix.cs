using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToManyEf.Migrations
{
    /// <inheritdoc />
    public partial class FinacialAidStatusFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "FinancialAidStatus",
                value: "Approved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "FinancialAidStatus",
                value: "Approved'");
        }
    }
}
