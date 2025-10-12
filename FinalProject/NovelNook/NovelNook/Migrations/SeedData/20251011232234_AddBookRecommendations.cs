using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovelNook.Migrations.SeedData
{
    /// <inheritdoc />
    public partial class AddBookRecommendations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookRecommendations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRecommendations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BookRecommendations",
                columns: new[] { "Id", "Author", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Blake Crouch", "A mind-bending thriller that explores the concept of alternate realities and the choices that define us. Jason Dessen, a college physics professor, is abducted and wakes up in a world where his life is completely different. As he navigates this new reality, he must confront the consequences of his choices and fight to return to his original life.", "Dark Matter" },
                    { 2, "Shauna Niequist", "A collection of essays that find beauty and meaning in the ordinary moments of life. Shauna Niequist shares her reflections on family, faith, and the simple joys that make life special, encouraging readers to appreciate the small things that often go unnoticed.", "Cold Tangerines: Celebrating the Extraordinary Nature of Everyday Life" },
                    { 3, "Jandy Nelson", "A young adult novel that tells the story of twins Noah and Jude, who are struggling to reconnect after a tragic event. The narrative alternates between their perspectives, revealing their secrets, dreams, and the complexities of their relationship as they navigate love, loss, and self-discovery.", "I'll give you the sun" },
                    { 4, "Claire Kendal", "A psychological thriller that delves into the dark side of obsession and the lengths people will go to protect their secrets.", "The Book of You" },
                    { 5, "Liane Moriarty", "A gripping novel that explores the lives of three women in a tight-knit community, unraveling the secrets and lies that lead to a shocking event at a school trivia night.", "Big Little Lies" },
                    { 6, "Caroline Kepnes", "A psychological thriller that follows Joe Goldberg, a bookstore manager who becomes infatuated with a customer named Beck. The story is told from Joe's perspective, revealing his obsessive and dangerous behavior as he manipulates those around him to win Beck's affection.", "You" },
                    { 7, "Neal Shusterman", "In a future where death has been conquered, two teenagers are chosen to become Scythes, the only ones who can end life to control population growth. As they learn the art of gleaning, they must navigate moral dilemmas and the corrupt world of the Scythedom.", "Scythe" },
                    { 8, "V.E. Schwab", "Vicious is a science fiction fantasy novel about two former college roommates, Victor Vale and Eli Ever, who turn into powerful arch-nemeses. After a shared research project goes horribly wrong, the two rivals develop extraordinary abilities and embark on a path of ambition, betrayal, and revenge. The story explores what happens when people gain superpowers in a world where there are no true heroes, only villains and anti-heroes with twisted motivations.", "Vicious" },
                    { 9, "Matt Haig", "In Notes on a Nervous Planet, Matt Haig explores the impact of modern life on mental health, addressing issues like anxiety, social media, and the fast pace of contemporary living. Through personal anecdotes and reflections, Haig offers insights and practical advice on how to navigate the challenges of the digital age while maintaining mental well-being.", "Notes on Nervous Planet" },
                    { 10, "A.S. King", "Dig is a young adult novel that follows the story of a teenage girl named Brynn, who is struggling to cope with the recent death of her father. As she navigates her grief, Brynn uncovers family secrets and confronts her own identity, leading to a journey of self-discovery and healing.", "Dig" },
                    { 11, "Beatrice the Biologist", "Everyday Amazing is a fascinating exploration of the science behind everyday phenomena. Beatrice the Biologist delves into the wonders of the natural world, explaining complex scientific concepts in an engaging and accessible way. From the chemistry of cooking to the physics of rainbows, this book reveals the extraordinary science that surrounds us in our daily lives.", "Everyday Amazing: Fascinating Facts About the Science That Surrounds Us" },
                    { 12, "Adam Grant", "Think Again: The Power of Knowing What You Don't Know by Adam Grant is about the importance of reexamining your beliefs and unlearning outdated knowledge to adapt and succeed in a rapidly changing world. Grant, an organizational psychologist, argues that what matters more than intelligence is \"mental flexibility\" and the willingness to question your own opinions.", "Think Again" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRecommendations");
        }
    }
}
