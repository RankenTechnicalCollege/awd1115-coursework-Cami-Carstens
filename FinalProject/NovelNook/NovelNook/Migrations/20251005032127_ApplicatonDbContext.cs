using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovelNook.Migrations
{
    /// <inheritdoc />
    public partial class ApplicatonDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfEntries_AspNetUsers_IdentityUserId",
                table: "BookshelfEntries");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "BookshelfEntries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfEntries_AspNetUsers_IdentityUserId",
                table: "BookshelfEntries",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookshelfEntries_AspNetUsers_IdentityUserId",
                table: "BookshelfEntries");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "BookshelfEntries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookshelfEntries_AspNetUsers_IdentityUserId",
                table: "BookshelfEntries",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
