using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovelNookBookStore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Discussions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpinionField = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Review = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discussions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnSale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnSale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decors",
                columns: table => new
                {
                    DecorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOnSale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decors", x => x.DecorId);
                    table.ForeignKey(
                        name: "FK_Decors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    DecorId = table.Column<int>(type: "int", nullable: true),
                    SaleItemId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DecorId1 = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Decors_DecorId",
                        column: x => x.DecorId,
                        principalTable: "Decors",
                        principalColumn: "DecorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Decors_DecorId1",
                        column: x => x.DecorId1,
                        principalTable: "Decors",
                        principalColumn: "DecorId");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_OrderItems_Sales_SaleItemId",
                        column: x => x.SaleItemId,
                        principalTable: "Sales",
                        principalColumn: "SaleId");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Book" },
                    { 2, "Home" }
                });

            migrationBuilder.InsertData(
                table: "Discussions",
                columns: new[] { "Id", "Author", "Genre", "OpinionField", "Review", "Title" },
                values: new object[,]
                {
                    { 1, "Leslye Walton", "Fiction", "The writing is so beautiful. I found myself getting emotional while reading. The story is so incredibly atmospheric and moody. You will smile and have your heart broken in the same sentence. It really is a strange and beautiful book as the title suggest. It is about the painful and beautiful aspect of humanity we all must walk.", 5, "The Strange and Beautiful Sorrows of Ava Lavender" },
                    { 2, "Blake Crouch", "Fiction", "This book made me feel tiny. It was overwhelming and scary, but oh so very gripping!\r\n\r\nDark Matter is the kind of compelling \"I must know WTF is going on\" book that makes you forget about everything else you had to do that day. You step into this world - this absolute mind trip of a world that will tug at both your heart strings and your brain cells - and you don't want to come out until you know how it ends. Real life? Who cares? Shit is going down and I need answers!.", 5, "Dark Matter" }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "Image", "ImageUrl", "IsOnSale", "SaleDescription", "SaleItemName", "SalePrice" },
                values: new object[,]
                {
                    { 1, null, "/Images/Wish-you-were-here.jpg", true, "Hard Cover - Gently used book. No marking or tears.", "Wish you were here", 9.99m },
                    { 2, null, "/Images/Atlas-Heart.jpg", true, "Hard Cover - Brand New-take a journey into your heart", "Atlas of the Heart", 14.99m },
                    { 3, null, "/Images/sisters-book.jpg", true, "Hard Cover - Like New- floor model book", "Sisters", 7.99m },
                    { 4, null, "/Images/goosebumps.jpg", true, "Soft Cover - Used-may contain a couple marks or creases, nothing obstructive", "Goosebumps", 4.99m },
                    { 5, null, "/Images/court-silver-flames.jpg", true, "Hard Cover - New - floor model book", "A Court of Silver Flames", 15.99m },
                    { 6, null, "Images/Book-Thumb.jpg", true, "6 pack. Variety of different stones. Easily hold your book open with these beautiful stone-crafted thumb page openers", "Thumb Book Holder", 30.99m },
                    { 7, null, "/Images/Hungry-Caterpillar.jpg", true, "Hard Cover- Like new", "The Very Hungry Catepillar", 6.99m },
                    { 8, null, "/Images/Outsiders-Book.jpg", true, "Soft Cover -  Good condition - no creases, tears, or highlighting", "Outsiders", 6.99m },
                    { 9, null, "/Images/James-Giant-Peach.jpg", true, "Soft Cover - New - Classic", "James and the Giant Peach", 5.99m },
                    { 10, null, "/Images/Book-Wreath.jpg", true, "Beautiful hand crafted wreath made form recycled book pages", "Book Wreath", 39.99m }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "Description", "Image", "ImageUrl", "IsOnSale", "LinkUrl", "Price", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "James Clear", 1, "No matter your goals, Atomic Habits offers a proven framework for improving--every day. James Clear, one of the world's leading experts on habit formation, reveals practical strategies that will teach you exactly how to form good habits, break bad ones, and master the tiny behaviors that lead to remarkable results", "/images/atomic-habits.jpg", null, false, "", 18.99m, 10, "Atomic Habits" },
                    { 2, "Shauna Niequist", 1, "A collection of essays that find beauty and meaning in the ordinary moments of life. Shauna Niequist shares her reflections on family, faith, and the simple joys that make life special, encouraging readers to appreciate the small things that often go unnoticed.", "/images/cold-tangerines.jpg", null, false, "", 16.99m, 20, "Cold Tangerines: Celebrating the Extraordinary Nature of Everyday Life" },
                    { 3, "Jandy Nelson", 1, "A young adult novel that tells the story of twins Noah and Jude, who are struggling to reconnect after a tragic event. The narrative alternates between their perspectives, revealing their secrets, dreams, and the complexities of their relationship as they navigate love, loss, and self-discovery.", "/images/ill-give-you-the-sun.jpg", null, false, "", 14.99m, 29, "I'll give you the sun" },
                    { 4, "Claire Kendal", 1, "A psychological thriller that delves into the dark side of obsession and the lengths people will go to protect their secrets.", "/images/book-of-you.jpg", null, false, "", 26.99m, 3, "The Book of You" },
                    { 5, "Liane Moriarty", 1, "A gripping novel that explores the lives of three women in a tight-knit community, unraveling the secrets and lies that lead to a shocking event at a school trivia night.", "/images/big-little-lies.jpg", null, false, "", 26.99m, 7, "Big Little Lies" },
                    { 6, "Caroline Kepnes", 1, "A psychological thriller that follows Joe Goldberg, a bookstore manager who becomes infatuated with a customer named Beck. The story is told from Joe's perspective, revealing his obsessive and dangerous behavior as he manipulates those around him to win Beck's affection.", "/images/you.jpg", null, false, "", 25.99m, 3, "You" },
                    { 7, "Neal Shusterman", 1, "In a future where death has been conquered, two teenagers are chosen to become Scythes, the only ones who can end life to control population growth. As they learn the art of gleaning, they must navigate moral dilemmas and the corrupt world of the Scythedom.", "/images/scythe.jpg", null, false, "", 17.99m, 3, "Scythe" },
                    { 8, "Stephen King", 1, "From legendary storyteller and master of short fiction Stephen King comes an extraordinary new collection of twelve short stories, many never-before-published, and some of his best EVER.", "/images/like-it-darker.jpg", null, false, "", 19.99m, 5, "You Like It Darker" },
                    { 9, "Matt Haig", 1, "In Notes on a Nervous Planet, Matt Haig explores the impact of modern life on mental health, addressing issues like anxiety, social media, and the fast pace of contemporary living. Through personal anecdotes and reflections, Haig offers insights and practical advice on how to navigate the challenges of the digital age while maintaining mental well-being.", "/images/nervous-planet.jpg", null, false, "", 16.99m, 7, "Notes on Nervous Planet" },
                    { 10, "A.S. King", 1, "Dig is a young adult novel that follows the story of a teenage girl named Brynn, who is struggling to cope with the recent death of her father. As she navigates her grief, Brynn uncovers family secrets and confronts her own identity, leading to a journey of self-discovery and healing.", "/images/dig.jpg", null, false, "", 18.99m, 8, "Dig" },
                    { 11, "Beatrice the Biologist", 1, "Everyday Amazing is a fascinating exploration of the science behind everyday phenomena. Beatrice the Biologist delves into the wonders of the natural world, explaining complex scientific concepts in an engaging and accessible way. From the chemistry of cooking to the physics of rainbows, this book reveals the extraordinary science that surrounds us in our daily lives.", "/images/everyday-amazing.jpg", null, false, "", 16.99m, 9, "Everyday Amazing: Fascinating Facts About the Science That Surrounds Us" },
                    { 12, "Rory Power", 1, "It's been eighteen months since the Raxter School for Girls was put under quarantine. Since the Tox hit and pulled Hetty's life out from under her.\r\n\r\nIt started slow. First the teachers died one by one. Then it began to infect the students, turning their bodies strange and foreign. Now, cut off from the rest of the world and left to fend for themselves on their island home, the girls don't dare wander outside the school's fence, where the Tox has made the woods wild and dangerous. They wait for the cure they were promised as the Tox seeps into everything.\r\n\r\nBut when Byatt goes missing, Hetty will do anything to find her, even if it means breaking quarantine and braving the horrors that lie beyond the fence. And when she does, Hetty learns that there's more to their story, to their life at Raxter, than she could have ever thought true.", "/images/wilder-girls.jpg", null, false, "", 24.99m, 22, "Wilder Girls" },
                    { 13, "M.L. Wang", 1, "Magic has made the city of Tiran an industrial utopia, but magic has a cost. A dark academia brimming with mystery, tradegy, bravery, and damning echoes of the past. Through their fractious relationship, mage and outsider uncover an ancient secret that could change the course of magic forever—if it doesn’t get them killed first. Sciona has defined her life by the pursuit of truth, but how much is one truth worth with the fate of civilization in the balance?", "/images/Blood-over-bright-haven.jpg", null, false, "", 22.99m, 14, "Blood Over Bright Haven" },
                    { 14, "John Paul Mueller, Luca Massaron, Stephanie Diamond", 1, "A comprehensive guide for non-technical users. Artificial intelligence (AI) is the science of creating computer systems that can perform tasks normally requiring human intelligence, such as learning, reasoning, and problem-solving. ", "/images/Ai-Dummies.jpg", null, false, "", 19.99m, 17, "Artificial Intelligence for Dummies" },
                    { 15, "Bell Hooks", 1, "All About Love: New Visions, bell hooks argues that love is not simply a feeling but a conscious, intentional choice. Hooks's central thesis is that \"love is as love does\". She explains that modern society has fundamentally misunderstood love by treating it as a noun—a mystical, passive emotion—rather than a verb, which implies intentional action and will.", "/images/all-about-love.jpg", null, false, "", 14.99m, 0, "All About Love" },
                    { 16, "Mary Delamater Joel Murach", 1, "Learn to write your first apps using MVC (Model-View-Controller) pattern. This book gets you off to a fast start whether or not you have prior experience with server-side development.\r\nIt teaches you all the skills you need to develop bulletproof, database-driven web apps. That includes using endpoint routing, Razor views, model binding, data validation, dependency injection, Bootstrap for responsive design, EF (Entity Framework) Core for database handling, xUnit and Moq for unit testing, and Identity for authentication", "/images/ASPNet.jpg", null, false, "", 59.50m, 12, "murach's ASP.NET Core MVC" },
                    { 17, "Shannon Lee", 1, " \"Empty your mind, be formless, shapeless—like water,\" was popularized by martial arts legend and philosopher Bruce Lee. The phrase is a core tenet of his philosophy, urging practitioners to become adaptable and fluid, both in combat and in life. \"Empty your mind, be formless, shapeless—like water. You put water into a cup, it becomes the cup. You put water into a bottle, it becomes the bottle. You put it in a teapot, it becomes the teapot. Now, water can flow or it can crash. Be water, my friend.", "/images/Be-Water-My-Friend.jpg", null, false, "", 16.99m, 15, "Be Water My Friend" },
                    { 18, "Tatsuki Fujimoto", 1, "Chainsaw Man, Vol. 1 introduces readers to Denji, a poor young man struggling with debt and despair. After being killed in a job, he is revived by his pet devil, Pochita, and transforms into Chainsaw Man, a powerful being with chainsaw-like abilities. The story follows Denji's journey as he seeks redemption and fights against devils, embodying humanity's darkest fears. The volume explores themes of hope, love, and the struggle for a better life, showcasing Denji's transformation and the bond he forms with Pochita. Denji is a small-time devil hunter just trying to survive in a harsh world. After being killed on a job, he is revived by his pet devil Pochita and becomes something new and dangerous—Chainsaw Man!", "/images/Chainsaw-man.jpg", null, false, "", 11.99m, 19, "Chainsaw Man Vol. 1" },
                    { 19, "E.B. White", 1, "Charlotte's Web is a classic 1952 children's novel by E.B. White about the unlikely friendship between a pig named Wilbur and a wise barn spider named Charlotte, who saves his life by spinning words in her web that praise him, preventing him from becoming pork chops. ", "/images/Charlottes-web.jpg", null, false, "", 8.99m, 23, "Charlotte's Web" },
                    { 20, "Marissa Meyer", 1, "Cinder by Marissa Meyer is the first book in The Lunar Chronicles, a young adult science fiction series that retells classic fairy tales in a futuristic, post-war world. The story follows Cinder, a cyborg mechanic in futuristic New Beijing, who is a second-class citizen with a hidden, mysterious past. When her life becomes entangled with Prince Kai, she finds herself at the center of an interplanetary struggle and a fight for Earth's survival against the tyrannical Queen Levana of the Lunar colony", "/images/Cinder.jpg", null, false, "", 12.99m, 24, "Cinder" },
                    { 21, "Ichiro Kishimi and Fumitake Koga", 1, "Having the courage to be disliked\" means accepting that you may face disapproval or criticism because you are living authentically and according to your own values, rather than trying to please others or conform to their expectations. It is the freedom to act according to your own beliefs and principles, even if it leads to rejection, and is seen as a pathway to genuine freedom and self-confidence", "/images/courage-disliked.jpg", null, false, "", 14.99m, 17, "The Courage to be Disliked" },
                    { 22, "V.E. Schwab", 1, "A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force", "/images/Darker-shade-of-magic.jpg", null, false, "", 22.99m, 2, "A Darker Shade of Magic" },
                    { 23, "Blake Crouch", 1, "A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force", "/images/Dark-matter.jpg", null, false, "", 19.99m, 6, "Dark Matter" },
                    { 24, "Daniel Goleman", 1, "a groundbreaking book that argues emotional intelligence (EI), encompassing self-awareness, impulse control, persistence, empathy, and social skills, is a more significant determinant of success than IQ. Drawing on psychology and neuroscience, the book explains how EI, which can be nurtured and developed, influences relationships, career success, and overall well-being, offering a new understanding of intelligence and a compelling vision for personal and societal growth.  ", "/images/Emotional-intelligence.jpg", null, false, "", 15.99m, 9, "Emotional Intelligence" },
                    { 25, "Jason Stanley", 1, "In Erasing History, Yale professor of philosophy Jason Stanley exposes the true danger of the authoritarian right’s attacks on education, identifies their key tactics and funders, and traces their intellectual roots. He illustrates how fears of a fascist future have metastasized, from hypothetical threat to present reality. And with his “urgent, piercing, and altogether brilliant” (Johnathan M. Metzl, author of What We’ve Become) insight, he illustrates that hearts and minds are won in our schools and universities—places that democratic societies across the world are now ill-prepared to defend against the fascist assault currently underway", "/images/Erasing-history.jpg", null, false, "", 23.99m, 10, "Erasing History" },
                    { 26, "Pierce Brown", 1, "Golden Son is the second novel in Pierce Brown's Red Rising Saga and follows Darrow as he continues his mission to destroy the Gold ruling class from within by becoming a leader among them after transforming from a lowborn Red to a Gold. The story expands on the political intrigue, betrayal, and warfare of the first book, with Darrow navigating treacherous alliances, growing his power, and preparing for a full-scale rebellion against the oppressive Society. \r\n", "/images/Golden-son.jpg", null, false, "", 19.99m, 13, "Golden Son" },
                    { 27, "Margeret Atwood", 1, "The Handmaid's Tale by Margaret Atwood is a dystopian novel published in 1985. Set in the near-future Republic of Gilead (formerly the United States), it follows Offred, a Handmaid whose sole purpose is to bear children for the ruling class. After environmental disasters cause a drastic drop in the birth rate, the totalitarian, patriarchal regime strips women of their rights and assigns them to specific social classes", "/images/handmaid-tale.jpg", null, false, "", 11.99m, 10, "The Handmaid's Tale" },
                    { 28, "Alicia Ortego", 1, "Kindness Is My Superpower is a children's book by Alicia Ortego that teaches young readers about empathy and compassion through the story of a boy named Lucas, who learns to make kindness his superpower. The book illustrates how simple acts like saying \"please\" and \"thank you,\" sharing, helping others, and apologizing can significantly impact others and create a positive environment. Through a heartwarming narrative, children learn that kindness, though sometimes challenging, is a source of inner strength and a powerful way to connect with the world around them", "/images/Kindness-is-My-Superpower.jpg", null, false, "", 14.99m, 0, "Kindness is my Superpower" },
                    { 29, "Marshall Loeb, Stephen Kindel", 1, "Leadership For Dummies is a practical guide that aims to teach anyone how to become a more effective leader, regardless of their current position or experience. The book moves beyond theory to provide hands-on strategies and techniques for developing leadership skills, building strong teams, and inspiring trust in others", "/images/Leadership-Dummies.jpg", null, false, "", 24.99m, 10, "Leadership for Dummies" },
                    { 30, "Anthony Doer", 1, "All the Light We Cannot See is a Pulitzer Prize-winning novel by Anthony Doerr that tells the parallel stories of a blind French girl and a German orphan boy during World War II. Their paths converge in the besieged French town of Saint-Malo as both struggle to survive the devastation of the war. ", "/images/Light-we-cannot-see.jpg", null, false, "", 22.99m, 20, "All the Light We Cannot See" },
                    { 31, "Adam Grant", 1, "Originals: How Non-Conformists Move the World by Adam Grant is a book that explores how to champion new and novel ideas, identify good ideas, speak up without being silenced, and build coalitions to bring disruptive concepts to life. Through stories and studies from various fields, Grant details the qualities of original people, provides tips for nurturing originality in children and leaders, and examines how fear and doubt can be managed on the path to innovation", "/images/Originals.jpg", null, false, "", 22.99m, 14, "Originals" },
                    { 32, "Howards Zinn", 1, "A People's History of the United States is a 1980 nonfiction book by historian Howard Zinn that tells the history of the country \"from the bottom up\". Zinn's work presents a different perspective than traditional narratives, focusing on the stories and struggles of marginalized groups rather than the powerful elites.", "/images/Peoples-history.jpg", null, false, "", 26.99m, 0, "People's History of the United States" },
                    { 33, "Karin Slaughter", 1, "Karin Slaughter's psychological thriller Pretty Girls centers on estranged sisters Claire and Lydia, who are forced to confront their family's devastating past when a new tragedy strikes. The book deals with themes of family trauma, secrets, and the nature of survival.", "/images/Pretty-girls.jpg", null, false, "", 22.99m, 15, "Pretty Girls" },
                    { 34, "Mark Reed", 1, " Python programming aimed at beginners. His books focus on a practical, hands-on approach to learning Python and often include real-world projects and exercises to help solidify understanding", "/images/Python.jpg", null, false, "", 56.50m, 17, "Python Programming" },
                    { 35, "Pierce Brown", 1, "Red Rising, written by Pierce Brown, is a science fiction novel that introduces a color-coded caste system where different classes of humanity occupy specific roles across the solar system. The story follows Darrow, a lowborn \"Red,\" who discovers the truth behind the oppressive society and embarks on a mission of vengeance and rebellion", "/images/Red-rising.jpg", null, false, "", 19.99m, 3, "Red Rising" },
                    { 36, "Alex Michaelides", 1, "The Silent Patient is a 2019 psychological thriller novel by Alex Michaelides about a psychotherapist who becomes obsessed with unraveling the mystery of his patient, a famous artist who has gone completely silent after murdering her husband", "/images/Silent-patient.jpg", null, false, "", 25.99m, 7, "The Silent Patient" },
                    { 37, "Adam Grant", 1, "Think Again: The Power of Knowing What You Don't Know by Adam Grant is about the importance of reexamining your beliefs and unlearning outdated knowledge to adapt and succeed in a rapidly changing world. Grant, an organizational psychologist, argues that what matters more than intelligence is \"mental flexibility\" and the willingness to question your own opinions.", "/images/Think-again.jpg", null, false, "", 22.99m, 8, "Think Again" },
                    { 38, "V.E. Schwab", 1, "V. E. Schwab's Vicious is a science fiction fantasy novel about two former college roommates, Victor Vale and Eli Ever, who turn into powerful arch-nemeses. After a shared research project goes horribly wrong, the two rivals develop extraordinary abilities and embark on a path of ambition, betrayal, and revenge. The story explores what happens when people gain superpowers in a world where there are no true heroes, only villains and anti-heroes with twisted motivations.", "/images/Vicious.jpg", null, false, "", 19.99m, 9, "Vicious" },
                    { 39, "Fredrik Backman", 1, "Fredrik Backman's My Friends is a story that alternates between the past and present, focusing on four teenage friends who find solace in each other on a pier, and a young woman named Louisa 25 years later. The past timeline reveals the intense bond between the friends—Ted, Yor, Ali, and the artist—as they navigate difficult home lives, with the artist becoming a symbol of hope. The present timeline follows Louisa, who, after losing her own best friend, receives the artist's famous painting and embarks on a journey to uncover its story. Ultimately, the book is a story about friendship, art, grief, and human connection, exploring how a single summer can impact lives for decades to come", "/images/my-friends.jpg", null, false, "", 25.99m, 19, "My Friends" },
                    { 40, "Wally Lamb", 1, "Corby Ledbetter is struggling. New fatherhood, the loss of his job, and a growing secret addiction have thrown his marriage to his beloved Emily into a tailspin. And that's before he causes the tragedy that tears the family apart.\r\n\r\nSentenced to prison, Corby struggles to survive life on the inside, where he bears witness to frightful acts of brutality but also experiences small acts of kindness and elemental kinship with a prison librarian who sees his light and some of his fellow offenders, including a tender-hearted cellmate and a troubled teen desperate for a role model. Buoyed by them and by his mother's enduring faith in him, Corby begins to transcend the boundaries of his confinement, sustained by his hope that mercy and reconciliation might still be possible. Can his crimes ever be forgiven by those he loves?", "/images/river-is-waiting.jpg", null, false, "", 26.99m, 20, "River Is Waiting" },
                    { 41, "Josie Shapiro", 1, "The stunning debut novel by the winner of the Allen & Unwin Commercial Fiction Prize. If you loved Lessons in Chemistry and Eleanor Oliphant is Completely Fine, you will adore Everything is Beautiful and Everything Hurts.\r\n\r\nMickey Bloom: five foot tall, dyslexic, and bullied at school. Mickey knows she's nothing special. Until one day, she discovers running.\r\n\r\nMickey's new-found talent makes her realise she's everything she thought she wasn't - powerful, strong and special. But her success comes at a cost, and the relentless training and pressure to win leaves Mickey broken, her dream in tatters.Years later, when Mickey is working in a dead-end job with a drop-kick boyfriend, her mother becomes seriously ill. After nursing her, Mickey realises the only way she can overcome her grief - and find herself - is to run again.A chance encounter with a stranger sees Mickey re-ignite her dreams. The two women form an unbreakable bond, as Mickey is shown what it means to run in the right direction.An unforgettable debut novel about change, family and grit, and what it takes to achieve your dreams.'Everything is Beautiful and Everything Hurts plunges the reader into the gruelling world of the long distance runner - every pleasure, every pain. Shapiro deftly weaves the coming-of-age story of Mickey Bloom into a gripping account of adult Bloom running the Auckland Marathon. This is compelling storytelling that exposes the sacrifices - physical and emotional - demanded of our sporting elite. Chilling, yet ultimately heartwarming, it celebrates success without flinching from staring down its brutal costs. A sophisticated debut that will capture the racing hearts of its readers.' - Sue Orr, author of Loop Tracks", "/images/everything-beautiful-hurts.jpg", null, false, "", 16.99m, 13, "Everything Is Beautiful and Everything Hurts " },
                    { 42, "George Orwell", 1, "A farm is taken over by its overworked, mistreated animals. With flaming idealism and stirring slogans, they set out to create a paradise of progress, justice, and equality. Thus the stage is set for one of the most telling satiric fables ever penned –a razor-edged fairy tale for grown-ups that records the evolution from revolution against tyranny to a totalitarianism just as terrible.\r\nWhen Animal Farm was first published, Stalinist Russia was seen as its target. Today it is devastatingly clear that wherever and whenever freedom is attacked, under whatever banner, the cutting clarity and savage comedy of George Orwell’s masterpiece have a meaning and message still ferociously fresh.", "/images/animal-farm.jpg", null, false, "", 9.99m, 4, "Animal Farm" }
                });

            migrationBuilder.InsertData(
                table: "Decors",
                columns: new[] { "DecorId", "CategoryId", "Description", "Image", "ImageUrl", "IsOnSale", "LinkUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 2, "Cuddle up with a book a hot chocolate. Wrap yourself in this luxurious and incredibly soft blanket and you will never want to stop reading.", "/images/reading-blanket.jpg", null, false, "", "Ultra soft plush reading blanket", 34.99m, 25 },
                    { 2, 2, "Everybody gets cold feet in the winter. Not anymore, with these incredibly warm and toast mid-calf socks. Your toes will thank you!", "/images/reading-socks.jpg", null, false, "", "Plush Reading Socks", 16.99m, 45 },
                    { 3, 2, "Cozy shaw to wrap yourself in. Includes deep pockets. And sealed arm holes so it stays on. ", "/images/wearable-blanket.jpg", null, false, "", "Reading Shaw", 24.99m, 18 },
                    { 4, 2, "Light this comforting candle next time you sit down to read. Smells like rich warm leather, smoky woods, amber and vanilla. Close your eyes you might find yourself transport to Mr Poe's library. ", "/images/edward-candle.jpg", null, false, "", "Edgar Allen Poe's Library Candle", 24.99m, 35 },
                    { 5, 2, "Revitalize your home and reading experience with this candle warming lamp. Releases sent with a flame, soot, or polluntants. Combines wood, glass and gold finish. ", "/images/candle-warming-lamp.jpg", null, false, "", "Candle Warming Lamp", 34.99m, 23 },
                    { 6, 2, "This acacia wood book stand is perfect for keeping your reading glasses, phone and drinks within reach during your reading experience. Keep your page marked and your book safely stored.", "/images/book-caddy.jpg", null, false, "", "Wooden Book Caddy", 24.99m, 60 },
                    { 7, 2, "Known for its calming and soothing properties. This heavy duty book will keep your books from failing and add great decor to all your shelves (or wherever else you like to store your books- HINT: Everywhere!).", "/images/bookend.jpg", null, false, "", "Amethyst Crystal Book End", 69.99m, 20 },
                    { 8, 2, "Practice mindfullness with this sand garden. Make patterns in the sand by rolling or raking the included miniature rake or groove rock. ", "/images/Home-Mindful_Garden.jpg", null, false, "", "Mindful Texture Sand Garden", 25.99m, 13 },
                    { 9, 2, "Miniature globe paperweight. If you need a confidence boost, you can literally hold the world in your hands. Rotates 360 degrees. Beautiful for your office, desk, or bookshelf. ", "/images/world-globe.jpg", null, false, "", "Glass Globe Paperweight", 29.99m, 11 },
                    { 10, 2, "Clip on reading light, lightweight enough to not weight down your book and fit in your bag. Don't let the dark keep you from reading! Take AAA batteries", "/images/reading-light.jpg", null, false, "", "Book Lover's Reading Light", 14.99m, 20 },
                    { 11, 2, "100% organic cotton Canvas bag with a reinforced base, a pocket for valuables, and a loop for keys. Comes with a Novel Nook exclusively currated print. Come prepared and carry your books everywhere.", "/images/tote-page.jpg", null, false, "", "Novel Nook Exclusive Tote", 34.99m, 60 },
                    { 12, 2, "Introducing our own set of 3 candles specifically currated with our customers in mind. The smells include: Frosted Pine, Old Books, and Echanted Forest. Light one or all three.", "/images/candle-pack.jpg", null, false, "", "Novel Nook Exclusive Candle Set", 39.99m, 22 },
                    { 13, 2, "Fill this ceramic vase with your favorite fresh flowers or store your utensils. Adorn your kitchen, or any space you wish with some bookish charm.8in tall and 6 in long. A great gift for the Pride and Predujice fan in your life.", "/images/PP-vase.jpg", null, false, "", "Large Book Vase-Pride and Prejudice", 24.99m, 7 },
                    { 14, 2, "Beautiful black smooth calfskin leather jounral with snap closure and a gray ribbon bookmark. 150 ivory, worn edge  85 gsm pages", "/images/leather-journal.jpg", null, false, "", "Black Leather Journal with Closure", 29.99m, 12 },
                    { 15, 2, "Make your reading experience more classy with these real leather and gold embossed corner book mars. 2 pack. A elegant addition to saving your spot in reading.", "/images/leather-bookmark.jpg", null, false, "", "Leatherette Corner Bookmarks", 9.99m, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Decors_CategoryId",
                table: "Decors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DecorId",
                table: "OrderItems",
                column: "DecorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DecorId1",
                table: "OrderItems",
                column: "DecorId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_SaleItemId",
                table: "OrderItems",
                column: "SaleItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Discussions");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Decors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
