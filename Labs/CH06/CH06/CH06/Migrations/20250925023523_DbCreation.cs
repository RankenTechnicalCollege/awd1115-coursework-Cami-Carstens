using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CH06.Migrations
{
    /// <inheritdoc />
    public partial class DbCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "fAQs",
                columns: table => new
                {
                    FAQId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fAQs", x => x.FAQId);
                    table.ForeignKey(
                        name: "FK_fAQs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_fAQs_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "TopicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { "gen", "General" },
                    { "hist", "History" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicId", "Name" },
                values: new object[,]
                {
                    { "asp", "ASP.NET Core" },
                    { "blz", "Blazor" },
                    { "ef", "Entity Framework" }
                });

            migrationBuilder.InsertData(
                table: "fAQs",
                columns: new[] { "FAQId", "Answer", "CategoryId", "Question", "TopicId" },
                values: new object[,]
                {
                    { 1, "ASP.NET Core is a free and open-sourced, cross-platform framework developed by Microsoft for building web applications and services.", "gen", "What is ASP.NET Core?", "asp" },
                    { 2, "ASP?NET Core 1.0 was released on June 27, 2016", "hist", "When was ASP.NET Core released?", "asp" },
                    { 3, "Blazor is an open-source, cross-platform web framework developed by Microsoft that enables developers to build interactive client-side web UIs using C# and .NET instead of JavaScript. It allows for the creation of modern web applications using a component-based model, similar to frameworks like React or Angular, but leveraging the .NET ecosystem.", "gen", "What is Blazor?", "blz" },
                    { 4, "Blazor was released on May 14, 2020", "hist", "When was Blazor released?", "blz" },
                    { 5, "Entity Framework is an open-source ORM framework for .NET applications supported by Microsoft. It enables developers to work with data using objects of domain-specific classes without focusing on the underlying database tables and columns where this data is stored.", "gen", "What is Entity Framework?", "ef" },
                    { 6, "Entity Framework 1.0 was released in 2008", "hist", "When was Entity Framework released?", "ef" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_fAQs_CategoryId",
                table: "fAQs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_fAQs_TopicId",
                table: "fAQs",
                column: "TopicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fAQs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Topics");
        }
    }
}
