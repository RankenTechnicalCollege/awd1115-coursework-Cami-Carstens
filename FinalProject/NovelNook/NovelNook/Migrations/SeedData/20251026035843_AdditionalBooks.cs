using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovelNook.Migrations.SeedData
{
    /// <inheritdoc />
    public partial class AdditionalBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ExploreCards",
                keyColumn: "Id",
                keyValue: 13,
                column: "Image",
                value: "/images/Erasing-history.jpg");

            migrationBuilder.InsertData(
                table: "ExploreCards",
                columns: new[] { "Id", "Author", "Description", "Image", "LinkUrl", "Title" },
                values: new object[,]
                {
                    { 27, "Fredrik Backman", "Fredrik Backman's My Friends is a story that alternates between the past and present, focusing on four teenage friends who find solace in each other on a pier, and a young woman named Louisa 25 years later. The past timeline reveals the intense bond between the friends—Ted, Yor, Ali, and the artist—as they navigate difficult home lives, with the artist becoming a symbol of hope. The present timeline follows Louisa, who, after losing her own best friend, receives the artist's famous painting and embarks on a journey to uncover its story. Ultimately, the book is a story about friendship, art, grief, and human connection, exploring how a single summer can impact lives for decades to come", "/images/my-friends.jpg", "", "My Friends" },
                    { 28, "Wally Lamb", "Corby Ledbetter is struggling. New fatherhood, the loss of his job, and a growing secret addiction have thrown his marriage to his beloved Emily into a tailspin. And that's before he causes the tragedy that tears the family apart.\r\n\r\nSentenced to prison, Corby struggles to survive life on the inside, where he bears witness to frightful acts of brutality but also experiences small acts of kindness and elemental kinship with a prison librarian who sees his light and some of his fellow offenders, including a tender-hearted cellmate and a troubled teen desperate for a role model. Buoyed by them and by his mother's enduring faith in him, Corby begins to transcend the boundaries of his confinement, sustained by his hope that mercy and reconciliation might still be possible. Can his crimes ever be forgiven by those he loves?", "/images/river-is-waiting.jpg", "", "River Is Waiting" },
                    { 29, "Josie Shapiro", "The stunning debut novel by the winner of the Allen & Unwin Commercial Fiction Prize. If you loved Lessons in Chemistry and Eleanor Oliphant is Completely Fine, you will adore Everything is Beautiful and Everything Hurts.\r\n\r\nMickey Bloom: five foot tall, dyslexic, and bullied at school. Mickey knows she's nothing special. Until one day, she discovers running.\r\n\r\nMickey's new-found talent makes her realise she's everything she thought she wasn't - powerful, strong and special. But her success comes at a cost, and the relentless training and pressure to win leaves Mickey broken, her dream in tatters.Years later, when Mickey is working in a dead-end job with a drop-kick boyfriend, her mother becomes seriously ill. After nursing her, Mickey realises the only way she can overcome her grief - and find herself - is to run again.A chance encounter with a stranger sees Mickey re-ignite her dreams. The two women form an unbreakable bond, as Mickey is shown what it means to run in the right direction.An unforgettable debut novel about change, family and grit, and what it takes to achieve your dreams.'Everything is Beautiful and Everything Hurts plunges the reader into the gruelling world of the long distance runner - every pleasure, every pain. Shapiro deftly weaves the coming-of-age story of Mickey Bloom into a gripping account of adult Bloom running the Auckland Marathon. This is compelling storytelling that exposes the sacrifices - physical and emotional - demanded of our sporting elite. Chilling, yet ultimately heartwarming, it celebrates success without flinching from staring down its brutal costs. A sophisticated debut that will capture the racing hearts of its readers.' - Sue Orr, author of Loop Tracks", "/images/everything-beautiful-hurts.jpg", "", "Everything Is Beautiful and Everything Hurts " },
                    { 30, "George Orwell", "A farm is taken over by its overworked, mistreated animals. With flaming idealism and stirring slogans, they set out to create a paradise of progress, justice, and equality. Thus the stage is set for one of the most telling satiric fables ever penned –a razor-edged fairy tale for grown-ups that records the evolution from revolution against tyranny to a totalitarianism just as terrible.\r\nWhen Animal Farm was first published, Stalinist Russia was seen as its target. Today it is devastatingly clear that wherever and whenever freedom is attacked, under whatever banner, the cutting clarity and savage comedy of George Orwell’s masterpiece have a meaning and message still ferociously fresh.", "/images/animal-farm.jpg", "", "Animal Farm" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExploreCards",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ExploreCards",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ExploreCards",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ExploreCards",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                table: "ExploreCards",
                keyColumn: "Id",
                keyValue: 13,
                column: "Image",
                value: "/images/Ai-Dummies.jpg");
        }
    }
}
