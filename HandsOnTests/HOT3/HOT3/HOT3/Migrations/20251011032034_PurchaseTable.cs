using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HOT3.Migrations
{
    /// <inheritdoc />
    public partial class PurchaseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoodieId",
                table: "Hoodies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoodieId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Hoodies_HoodieId",
                        column: x => x.HoodieId,
                        principalTable: "Hoodies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 1,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 2,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 3,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 4,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 5,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 6,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 7,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 8,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 9,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 10,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 11,
                column: "HoodieId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Hoodies",
                keyColumn: "Id",
                keyValue: 12,
                column: "HoodieId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_HoodieId",
                table: "Purchases",
                column: "HoodieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropColumn(
                name: "HoodieId",
                table: "Hoodies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Material",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Hoodies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
