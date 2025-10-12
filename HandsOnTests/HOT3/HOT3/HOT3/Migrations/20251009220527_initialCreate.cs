using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HOT3.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Hoodies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoodies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hoodies_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "Men's" },
                    { 2, "Women's" }
                });

            migrationBuilder.InsertData(
                table: "Hoodies",
                columns: new[] { "Id", "Brand", "CategoryId", "Color", "Description", "ImageFileName", "Material", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Urban Threads", 1, "Gray", "A classic hoodie for everyday wear.", "mens-classic-hoodie.jpg", "Cotton", "Classic Hoodie", 49.99m },
                    { 2, "Cozy Core", 2, "Creamed Coffee", "Cozy, oversized silhouette with exaggerated balloon sleeve.", "balloon-sleeve.jpg", "Cotton and polyester blend", "Oversized Balloon Sleeved Hoodie", 59.99m },
                    { 3, "Everyday Essentials", 1, "French vanilla", "A perfectly cozy hoodie with a boxy cut.", "classic.hoodie.jpg", "Cotton", "Classic Hoodie with a Boxy cut", 69.99m },
                    { 4, "Cozy Core", 2, "Destressed Black", "A unique hoodie full of vintage character. A true lived in feeling.", "destroyed-hoodie2.jpg", "Cotton", "Destroyed Hoodie", 54.99m },
                    { 5, "Urban Threads", 1, "Gray", "A warm fleece hoodie for colder days. Or a curl up on the couch hoodie to keep you warm and comfy,", "fleece-lined-hoodie.jpg", "Cotten and Fleece", "Fleece Lined Hoodie", 64.99m },
                    { 6, "Urban Threads", 1, "Washed Black", "Like your favorite hoodie you've had for years and always grab first.", "faded-hoodie.jpg", "Cotton", "Washed/Faded Hoodie", 44.99m },
                    { 7, "Vintage Vibes", 2, "Multi flower", "A trendy oversized hoodie with a beautiful boho design.", "flower-hoodie.jpg", "Cotton Blend", "Oversized Flower Hoodie", 59.99m },
                    { 8, "Urban Threads", 1, "Caramel Latte", "A hoodie made from sustainable materials. Designed with a cropped and boxy fit to hit you at just the perfect place. ", "mens-boxy-cropped.jpg", "Organic Cotton and recycled polyester", "Boxy-Cropped Hoodie", 74.99m },
                    { 9, "Cozy Core", 2, "Lavender bouqet", "A hoodie with balloon sleeves, optional side splits, soft french terry lining. Oversized fit.", "Oversized-hoodie.jpg", "Cotten", "Plus size Hoodie", 79.99m },
                    { 10, "Everyday Essentials", 2, "Mustard Olive", "A hoodie with a vintage look and feel. Extra cozy. Wear on a walk, on the couch, or the grocery store.", "womens-cotton-hoodie.jpg", "Cotton and Polyester", "Vintage Hoodie", 69.99m },
                    { 11, "Vintage Vibes", 2, "Red Goddess", "A stylish cropped hoodie. With the most amazing lived in fabric feel.", "womens-cropped.jpg", "Cotton", "Cropped Hoodie", 54.99m },
                    { 12, "Urban Threads", 1, "Beige", "Brushed cotton and rayon for extra softness. A washed fabric with a zip up design.", "zip-up.jpg", "Cotton and rayon", "Brushed vintage zip up hoodie", 79.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoodies_CategoryId",
                table: "Hoodies",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoodies");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
