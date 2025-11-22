using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NovelNookBookStore.Models;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Decor> Decors { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<BookReview> BookReviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderItem>()
              .HasOne(oi => oi.Book)
             .WithMany()
            .HasForeignKey(oi => oi.BookId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Decor)
                .WithMany()
                .HasForeignKey(oi => oi.DecorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade); // cascade delete here is fine




            //Seed Data
            //1.)Category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Book",

                },
                new Category
                {
                    CategoryId = 2,
                    Name = "Home"
                });


            //Table 2.) Book
          
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Atomic Habits",
                    Author = "James Clear",
                    Description = "No matter your goals, Atomic Habits offers a proven framework for improving--every day. James Clear, one of the world's leading experts on habit formation, reveals practical strategies that will teach you exactly how to form good habits, break bad ones, and master the tiny behaviors that lead to remarkable results",
                    Price = 18.99m,
                    Stock = 10,
                    Image = "/images/atomic-habits.jpg",
                    LinkUrl = "",
                    CategoryId =1,
                    IsOnSale = false

                },
                new Book
                {
                    BookId = 2,
                    Title = "Cold Tangerines: Celebrating the Extraordinary Nature of Everyday Life",
                    Author = "Shauna Niequist",
                    Description = "A collection of essays that find beauty and meaning in the ordinary moments of life. Shauna Niequist shares her reflections on family, faith, and the simple joys that make life special, encouraging readers to appreciate the small things that often go unnoticed.",
                    Price = 16.99m,
                    Stock = 20,
                    Image = "/images/cold-tangerines.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 3,
                    Title = "I'll give you the sun",
                    Author = "Jandy Nelson",
                    Description = "A young adult novel that tells the story of twins Noah and Jude, who are struggling to reconnect after a tragic event. The narrative alternates between their perspectives, revealing their secrets, dreams, and the complexities of their relationship as they navigate love, loss, and self-discovery.",
                    Price = 14.99m,
                   Stock=29,
                    Image = "/images/ill-give-you-the-sun.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false

                },
                new Book
                { 
                    BookId = 4,
                    Title = "The Book of You",
                    Author = "Claire Kendal",
                    Description = "A psychological thriller that delves into the dark side of obsession and the lengths people will go to protect their secrets.",
                    Price = 26.99m,
                   Stock=3,
                    Image = "/images/book-of-you.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 5,
                    Title = "Big Little Lies",
                    Author = "Liane Moriarty",
                    Description = "A gripping novel that explores the lives of three women in a tight-knit community, unraveling the secrets and lies that lead to a shocking event at a school trivia night.",
                    Price = 26.99m,
                    Stock = 7,
                    Image = "/images/big-little-lies.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false

                },
                new Book
                {
                    BookId = 6,
                    Title = "You",
                    Author = "Caroline Kepnes",
                    Description = "A psychological thriller that follows Joe Goldberg, a bookstore manager who becomes infatuated with a customer named Beck. The story is told from Joe's perspective, revealing his obsessive and dangerous behavior as he manipulates those around him to win Beck's affection.",
                    Price = 25.99m,
                    Stock=3,
                    Image = "/images/you.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 7,
                    Title = "Scythe",
                    Author = "Neal Shusterman",
                    Description = "In a future where death has been conquered, two teenagers are chosen to become Scythes, the only ones who can end life to control population growth. As they learn the art of gleaning, they must navigate moral dilemmas and the corrupt world of the Scythedom.",
                    Price= 17.99m,
                    Stock=3,
                    Image = "/images/scythe.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false

                },
                new Book
                {
                    BookId = 8,
                    Title = "You Like It Darker",
                    Author = "Stephen King",
                    Description = "From legendary storyteller and master of short fiction Stephen King comes an extraordinary new collection of twelve short stories, many never-before-published, and some of his best EVER.",
                    Price = 19.99m,
                    Stock = 5,
                    Image = "/images/like-it-darker.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false

                },
                new Book
                {
                    BookId = 9,
                    Title = "Notes on Nervous Planet",
                    Author = "Matt Haig",
                    Description = "In Notes on a Nervous Planet, Matt Haig explores the impact of modern life on mental health, addressing issues like anxiety, social media, and the fast pace of contemporary living. Through personal anecdotes and reflections, Haig offers insights and practical advice on how to navigate the challenges of the digital age while maintaining mental well-being.",
                    Price = 16.99m,
                    Stock = 7,
                    Image = "/images/nervous-planet.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 10,
                    Title = "Dig",
                    Author = "A.S. King",
                    Description = "Dig is a young adult novel that follows the story of a teenage girl named Brynn, who is struggling to cope with the recent death of her father. As she navigates her grief, Brynn uncovers family secrets and confronts her own identity, leading to a journey of self-discovery and healing.",
                   Price = 18.99m,
                   Stock = 8,
                    Image = "/images/dig.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 11,
                    Title = "Everyday Amazing: Fascinating Facts About the Science That Surrounds Us",
                    Author = "Beatrice the Biologist",
                    Description = "Everyday Amazing is a fascinating exploration of the science behind everyday phenomena. Beatrice the Biologist delves into the wonders of the natural world, explaining complex scientific concepts in an engaging and accessible way. From the chemistry of cooking to the physics of rainbows, this book reveals the extraordinary science that surrounds us in our daily lives.",
                    Price = 16.99m,
                    Stock = 9,
                    Image = "/images/everyday-amazing.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 12,
                    Title = "Wilder Girls",
                    Author = "Rory Power",
                    Description = "It's been eighteen months since the Raxter School for Girls was put under quarantine. Since the Tox hit and pulled Hetty's life out from under her.\r\n\r\nIt started slow. First the teachers died one by one. Then it began to infect the students, turning their bodies strange and foreign. Now, cut off from the rest of the world and left to fend for themselves on their island home, the girls don't dare wander outside the school's fence, where the Tox has made the woods wild and dangerous. They wait for the cure they were promised as the Tox seeps into everything.\r\n\r\nBut when Byatt goes missing, Hetty will do anything to find her, even if it means breaking quarantine and braving the horrors that lie beyond the fence. And when she does, Hetty learns that there's more to their story, to their life at Raxter, than she could have ever thought true.",
                    Price = 24.99m,
                    Stock = 22,
                    Image = "/images/wilder-girls.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false

                },
                new Book
                {
                    BookId = 13,
                    Title = "Blood Over Bright Haven",
                    Description = "Magic has made the city of Tiran an industrial utopia, but magic has a cost. A dark academia brimming with mystery, tradegy, bravery, and damning echoes of the past. Through their fractious relationship, mage and outsider uncover an ancient secret that could change the course of magic forever—if it doesn’t get them killed first. Sciona has defined her life by the pursuit of truth, but how much is one truth worth with the fate of civilization in the balance?",
                    Author = "M.L. Wang",
                    Price = 22.99m,
                    Stock = 14,
                    Image = "/images/Blood-over-bright-haven.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 14,
                    Title = "Artificial Intelligence for Dummies",
                    Description = "A comprehensive guide for non-technical users. Artificial intelligence (AI) is the science of creating computer systems that can perform tasks normally requiring human intelligence, such as learning, reasoning, and problem-solving. ",
                    Author = "John Paul Mueller, Luca Massaron, Stephanie Diamond",
                    Price = 19.99m,
                    Stock = 17,
                    Image = "/images/Ai-Dummies.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },

            new Book
            {
                BookId = 15,
                Title = "All About Love",
                Description = "All About Love: New Visions, bell hooks argues that love is not simply a feeling but a conscious, intentional choice. Hooks's central thesis is that \"love is as love does\". She explains that modern society has fundamentally misunderstood love by treating it as a noun—a mystical, passive emotion—rather than a verb, which implies intentional action and will.",
                Author = "Bell Hooks",
                Price = 14.99m,
                Image = "/images/all-about-love.jpg",
                LinkUrl = "",
                CategoryId = 1,
                IsOnSale = false
            },

              new Book
              {
                  BookId = 16,
                  Title = "murach's ASP.NET Core MVC",
                  Description = "Learn to write your first apps using MVC (Model-View-Controller) pattern. This book gets you off to a fast start whether or not you have prior experience with server-side development.\r\nIt teaches you all the skills you need to develop bulletproof, database-driven web apps. That includes using endpoint routing, Razor views, model binding, data validation, dependency injection, Bootstrap for responsive design, EF (Entity Framework) Core for database handling, xUnit and Moq for unit testing, and Identity for authentication",
                  Author = "Mary Delamater Joel Murach",
                  Price = 59.50m,
                  Stock = 12,
                  Image = "/images/ASPNet.jpg",
                  LinkUrl = "",
                  CategoryId = 1,
                  IsOnSale = false
              },
                 new Book
                 {
                     BookId = 17,
                     Title = "Be Water My Friend",
                     Description = " \"Empty your mind, be formless, shapeless—like water,\" was popularized by martial arts legend and philosopher Bruce Lee. The phrase is a core tenet of his philosophy, urging practitioners to become adaptable and fluid, both in combat and in life. \"Empty your mind, be formless, shapeless—like water. You put water into a cup, it becomes the cup. You put water into a bottle, it becomes the bottle. You put it in a teapot, it becomes the teapot. Now, water can flow or it can crash. Be water, my friend.",
                     Author = "Shannon Lee",
                     Price = 16.99m,
                     Stock = 15,
                     Image = "/images/Be-Water-My-Friend.jpg",
                     LinkUrl = "",
                     CategoryId = 1,
                     IsOnSale = false
                 },
                 new Book
                 {
                     BookId = 18,
                     Title = "Chainsaw Man Vol. 1",
                     Description = "Chainsaw Man, Vol. 1 introduces readers to Denji, a poor young man struggling with debt and despair. After being killed in a job, he is revived by his pet devil, Pochita, and transforms into Chainsaw Man, a powerful being with chainsaw-like abilities. The story follows Denji's journey as he seeks redemption and fights against devils, embodying humanity's darkest fears. The volume explores themes of hope, love, and the struggle for a better life, showcasing Denji's transformation and the bond he forms with Pochita. Denji is a small-time devil hunter just trying to survive in a harsh world. After being killed on a job, he is revived by his pet devil Pochita and becomes something new and dangerous—Chainsaw Man!",
                     Price = 11.99m,
                     Stock = 19,
                     Author = "Tatsuki Fujimoto",
                     Image = "/images/Chainsaw-man.jpg",
                     LinkUrl = "",
                     CategoryId = 1,
                     IsOnSale = false
                 },
                 new Book
                 {
                     BookId = 19,
                     Title = "Charlotte's Web",
                     Description = "Charlotte's Web is a classic 1952 children's novel by E.B. White about the unlikely friendship between a pig named Wilbur and a wise barn spider named Charlotte, who saves his life by spinning words in her web that praise him, preventing him from becoming pork chops. ",
                     Author = "E.B. White",
                     Price = 8.99m,
                     Stock = 23,
                     Image = "/images/Charlottes-web.jpg",
                     LinkUrl = "",
                     CategoryId = 1,
                     IsOnSale = false
                 },
                 new Book
                 {
                     BookId = 20,
                     Title = "Cinder",
                     Description = "Cinder by Marissa Meyer is the first book in The Lunar Chronicles, a young adult science fiction series that retells classic fairy tales in a futuristic, post-war world. The story follows Cinder, a cyborg mechanic in futuristic New Beijing, who is a second-class citizen with a hidden, mysterious past. When her life becomes entangled with Prince Kai, she finds herself at the center of an interplanetary struggle and a fight for Earth's survival against the tyrannical Queen Levana of the Lunar colony",
                     Author = "Marissa Meyer",
                     Price = 12.99m,
                     Stock = 24,
                     Image = "/images/Cinder.jpg",
                     LinkUrl = "",
                     CategoryId = 1,
                     IsOnSale = false
                 },
                 new Book
                 {
                     BookId = 21,
                     Title = "The Courage to be Disliked",
                     Description = "Having the courage to be disliked\" means accepting that you may face disapproval or criticism because you are living authentically and according to your own values, rather than trying to please others or conform to their expectations. It is the freedom to act according to your own beliefs and principles, even if it leads to rejection, and is seen as a pathway to genuine freedom and self-confidence",
                     Author = "Ichiro Kishimi and Fumitake Koga",
                     Price = 14.99m,
                     Stock =  17,
                     Image = "/images/courage-disliked.jpg",
                     LinkUrl = "",
                     CategoryId = 1,
                     IsOnSale = false
                 },
                  new Book
                  {
                      BookId = 22,
                      Title = "A Darker Shade of Magic",
                      Description = "A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force",
                      Author = "V.E. Schwab",
                      Price = 22.99m,
                      Stock = 2,
                      Image = "/images/Darker-shade-of-magic.jpg",
                      LinkUrl = "",
                      CategoryId = 1,
                      IsOnSale = false

                  },
                  new Book
                  {
                      BookId = 23,
                      Title = "Dark Matter",
                      Description = "A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force",
                      Author = "Blake Crouch",
                      Price = 19.99m,
                      Stock = 6,
                      Image = "/images/Dark-matter.jpg",
                      LinkUrl = "",
                      CategoryId = 1,
                      IsOnSale = false
                  },
                   new Book
                   {
                       BookId = 24,
                       Title = "Emotional Intelligence",
                       Description = "a groundbreaking book that argues emotional intelligence (EI), encompassing self-awareness, impulse control, persistence, empathy, and social skills, is a more significant determinant of success than IQ. Drawing on psychology and neuroscience, the book explains how EI, which can be nurtured and developed, influences relationships, career success, and overall well-being, offering a new understanding of intelligence and a compelling vision for personal and societal growth.  ",
                       Author = "Daniel Goleman",
                       Price = 15.99m,
                       Stock = 9,
                       Image = "/images/Emotional-intelligence.jpg",
                       LinkUrl = "",
                       CategoryId = 1,
                       IsOnSale = false
                   },
                  new Book
                  {
                      BookId = 25,
                      Title = "Erasing History",
                      Description = "In Erasing History, Yale professor of philosophy Jason Stanley exposes the true danger of the authoritarian right’s attacks on education, identifies their key tactics and funders, and traces their intellectual roots. He illustrates how fears of a fascist future have metastasized, from hypothetical threat to present reality. And with his “urgent, piercing, and altogether brilliant” (Johnathan M. Metzl, author of What We’ve Become) insight, he illustrates that hearts and minds are won in our schools and universities—places that democratic societies across the world are now ill-prepared to defend against the fascist assault currently underway",
                      Author = "Jason Stanley",
                      Price = 23.99m,
                      Stock = 10,
                      Image = "/images/Erasing-history.jpg",
                      LinkUrl = "",
                      CategoryId = 1,
                      IsOnSale = false
                  },
                new Book
                {
                    BookId = 26,
                    Title = "Golden Son",
                    Description = "Golden Son is the second novel in Pierce Brown's Red Rising Saga and follows Darrow as he continues his mission to destroy the Gold ruling class from within by becoming a leader among them after transforming from a lowborn Red to a Gold. The story expands on the political intrigue, betrayal, and warfare of the first book, with Darrow navigating treacherous alliances, growing his power, and preparing for a full-scale rebellion against the oppressive Society. \r\n",
                    Price = 19.99m,
                    Stock = 13,
                    Author = "Pierce Brown",
                    Image = "/images/Golden-son.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 27,
                    Title = "The Handmaid's Tale",
                    Description = "The Handmaid's Tale by Margaret Atwood is a dystopian novel published in 1985. Set in the near-future Republic of Gilead (formerly the United States), it follows Offred, a Handmaid whose sole purpose is to bear children for the ruling class. After environmental disasters cause a drastic drop in the birth rate, the totalitarian, patriarchal regime strips women of their rights and assigns them to specific social classes",
                    Author = "Margeret Atwood",
                    Price = 11.99m,
                    Stock = 10,
                    Image = "/images/handmaid-tale.jpg",
                    LinkUrl = "",
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 28,
                    Title = "Kindness is my Superpower",
                    Description = "Kindness Is My Superpower is a children's book by Alicia Ortego that teaches young readers about empathy and compassion through the story of a boy named Lucas, who learns to make kindness his superpower. The book illustrates how simple acts like saying \"please\" and \"thank you,\" sharing, helping others, and apologizing can significantly impact others and create a positive environment. Through a heartwarming narrative, children learn that kindness, though sometimes challenging, is a source of inner strength and a powerful way to connect with the world around them",
                    Price = 14.99m,
                    Author = "Alicia Ortego",
                    Image = "/images/Kindness-is-My-Superpower.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 29,
                    Title = "Leadership for Dummies",
                    Description = "Leadership For Dummies is a practical guide that aims to teach anyone how to become a more effective leader, regardless of their current position or experience. The book moves beyond theory to provide hands-on strategies and techniques for developing leadership skills, building strong teams, and inspiring trust in others",
                    Author = "Marshall Loeb, Stephen Kindel",
                    Price = 24.99m,
                    Stock= 10,
                    Image = "/images/Leadership-Dummies.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 30,
                    Title = "All the Light We Cannot See",
                    Description = "All the Light We Cannot See is a Pulitzer Prize-winning novel by Anthony Doerr that tells the parallel stories of a blind French girl and a German orphan boy during World War II. Their paths converge in the besieged French town of Saint-Malo as both struggle to survive the devastation of the war. ",
                    Author = "Anthony Doer",
                    Price = 22.99m,
                    Stock = 20,
                    Image = "/images/Light-we-cannot-see.jpg",
                    LinkUrl = "",
                       CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 31,
                    Title = "Originals",
                    Description = "Originals: How Non-Conformists Move the World by Adam Grant is a book that explores how to champion new and novel ideas, identify good ideas, speak up without being silenced, and build coalitions to bring disruptive concepts to life. Through stories and studies from various fields, Grant details the qualities of original people, provides tips for nurturing originality in children and leaders, and examines how fear and doubt can be managed on the path to innovation",
                    Author = "Adam Grant",
                    Price = 22.99m,
                    Stock = 14,
                    Image = "/images/Originals.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 32,
                    Title = "People's History of the United States",
                    Description = "A People's History of the United States is a 1980 nonfiction book by historian Howard Zinn that tells the history of the country \"from the bottom up\". Zinn's work presents a different perspective than traditional narratives, focusing on the stories and struggles of marginalized groups rather than the powerful elites.",
                    Author = "Howards Zinn",
                    Price = 26.99m,
                    Image = "/images/Peoples-history.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 33,
                    Title = "Pretty Girls",
                    Description = "Karin Slaughter's psychological thriller Pretty Girls centers on estranged sisters Claire and Lydia, who are forced to confront their family's devastating past when a new tragedy strikes. The book deals with themes of family trauma, secrets, and the nature of survival.",
                    Author = "Karin Slaughter",
                    Price = 22.99m,
                    Stock= 15,
                    Image = "/images/Pretty-girls.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 34,
                    Title = "Python Programming",
                    Description = " Python programming aimed at beginners. His books focus on a practical, hands-on approach to learning Python and often include real-world projects and exercises to help solidify understanding",
                    Author = "Mark Reed",
                    Price = 56.50m,
                    Stock = 17,
                    Image = "/images/Python.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 35,
                    Title = "Red Rising",
                    Description = "Red Rising, written by Pierce Brown, is a science fiction novel that introduces a color-coded caste system where different classes of humanity occupy specific roles across the solar system. The story follows Darrow, a lowborn \"Red,\" who discovers the truth behind the oppressive society and embarks on a mission of vengeance and rebellion",
                    Author = "Pierce Brown",
                    Price = 19.99m,
                    Stock = 3,
                    Image = "/images/Red-rising.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 36,
                    Title = "The Silent Patient",
                    Description = "The Silent Patient is a 2019 psychological thriller novel by Alex Michaelides about a psychotherapist who becomes obsessed with unraveling the mystery of his patient, a famous artist who has gone completely silent after murdering her husband",
                    Author = "Alex Michaelides",
                    Price = 25.99m,
                    Stock = 7,
                    Image = "/images/Silent-patient.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 37,
                    Title = "Think Again",
                    Description = "Think Again: The Power of Knowing What You Don't Know by Adam Grant is about the importance of reexamining your beliefs and unlearning outdated knowledge to adapt and succeed in a rapidly changing world. Grant, an organizational psychologist, argues that what matters more than intelligence is \"mental flexibility\" and the willingness to question your own opinions.",
                    Author = "Adam Grant",
                    Price = 22.99m,
                    Stock = 8,
                    Image = "/images/Think-again.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 38,
                    Title = "Vicious",
                    Description = "V. E. Schwab's Vicious is a science fiction fantasy novel about two former college roommates, Victor Vale and Eli Ever, who turn into powerful arch-nemeses. After a shared research project goes horribly wrong, the two rivals develop extraordinary abilities and embark on a path of ambition, betrayal, and revenge. The story explores what happens when people gain superpowers in a world where there are no true heroes, only villains and anti-heroes with twisted motivations.",
                    Author = "V.E. Schwab",
                    Price = 19.99m,
                    Stock = 9,
                    Image = "/images/Vicious.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 39,
                    Title = "My Friends",
                    Description = "Fredrik Backman's My Friends is a story that alternates between the past and present, focusing on four teenage friends who find solace in each other on a pier, and a young woman named Louisa 25 years later. The past timeline reveals the intense bond between the friends—Ted, Yor, Ali, and the artist—as they navigate difficult home lives, with the artist becoming a symbol of hope. The present timeline follows Louisa, who, after losing her own best friend, receives the artist's famous painting and embarks on a journey to uncover its story. Ultimately, the book is a story about friendship, art, grief, and human connection, exploring how a single summer can impact lives for decades to come",
                    Author = "Fredrik Backman",
                    Price = 25.99m,
                    Stock = 19,
                    Image = "/images/my-friends.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                new Book
                {
                    BookId = 40,
                    Title = "River Is Waiting",
                    Description = "Corby Ledbetter is struggling. New fatherhood, the loss of his job, and a growing secret addiction have thrown his marriage to his beloved Emily into a tailspin. And that's before he causes the tragedy that tears the family apart.\r\n\r\nSentenced to prison, Corby struggles to survive life on the inside, where he bears witness to frightful acts of brutality but also experiences small acts of kindness and elemental kinship with a prison librarian who sees his light and some of his fellow offenders, including a tender-hearted cellmate and a troubled teen desperate for a role model. Buoyed by them and by his mother's enduring faith in him, Corby begins to transcend the boundaries of his confinement, sustained by his hope that mercy and reconciliation might still be possible. Can his crimes ever be forgiven by those he loves?",
                    Author = "Wally Lamb",
                    Price = 26.99m,
                    Stock = 20,
                    Image = "/images/river-is-waiting.jpg",
                    LinkUrl = "",
                    CategoryId = 1,
                    IsOnSale = false
                },
                   new Book
                   {
                       BookId = 41,
                       Title = "Everything Is Beautiful and Everything Hurts ",
                       Description = "The stunning debut novel by the winner of the Allen & Unwin Commercial Fiction Prize. If you loved Lessons in Chemistry and Eleanor Oliphant is Completely Fine, you will adore Everything is Beautiful and Everything Hurts.\r\n\r\nMickey Bloom: five foot tall, dyslexic, and bullied at school. Mickey knows she's nothing special. Until one day, she discovers running.\r\n\r\nMickey's new-found talent makes her realise she's everything she thought she wasn't - powerful, strong and special. But her success comes at a cost, and the relentless training and pressure to win leaves Mickey broken, her dream in tatters.Years later, when Mickey is working in a dead-end job with a drop-kick boyfriend, her mother becomes seriously ill. After nursing her, Mickey realises the only way she can overcome her grief - and find herself - is to run again.A chance encounter with a stranger sees Mickey re-ignite her dreams. The two women form an unbreakable bond, as Mickey is shown what it means to run in the right direction.An unforgettable debut novel about change, family and grit, and what it takes to achieve your dreams.'Everything is Beautiful and Everything Hurts plunges the reader into the gruelling world of the long distance runner - every pleasure, every pain. Shapiro deftly weaves the coming-of-age story of Mickey Bloom into a gripping account of adult Bloom running the Auckland Marathon. This is compelling storytelling that exposes the sacrifices - physical and emotional - demanded of our sporting elite. Chilling, yet ultimately heartwarming, it celebrates success without flinching from staring down its brutal costs. A sophisticated debut that will capture the racing hearts of its readers.' - Sue Orr, author of Loop Tracks",
                       Author = "Josie Shapiro",
                       Price = 16.99m,
                       Stock = 13,
                       Image = "/images/everything-beautiful-hurts.jpg",
                       LinkUrl = "",
                       CategoryId = 1,
                       IsOnSale = false
                   },
                      new Book
                      {
                          BookId = 42,
                          Title = "Animal Farm",
                          Description = "A farm is taken over by its overworked, mistreated animals. With flaming idealism and stirring slogans, they set out to create a paradise of progress, justice, and equality. Thus the stage is set for one of the most telling satiric fables ever penned –a razor-edged fairy tale for grown-ups that records the evolution from revolution against tyranny to a totalitarianism just as terrible.\r\nWhen Animal Farm was first published, Stalinist Russia was seen as its target. Today it is devastatingly clear that wherever and whenever freedom is attacked, under whatever banner, the cutting clarity and savage comedy of George Orwell’s masterpiece have a meaning and message still ferociously fresh.",
                          Author = "George Orwell",
                          Price = 9.99m,
                          Stock = 4,
                          Image = "/images/animal-farm.jpg",
                          LinkUrl = "",
                          CategoryId = 1,
                          IsOnSale = false
                      } );


     //3.)Decor Table
            modelBuilder.Entity<Decor>().HasData(
                new Decor
                {
                    DecorId = 1,
                    Name = "Ultra soft plush reading blanket",
                    Description = "Cuddle up with a book a hot chocolate. Wrap yourself in this luxurious and incredibly soft blanket and you will never want to stop reading.",
                    Price = 34.99m,
                    Stock = 25,
                    Image = "/images/reading-blanket.jpg",
                    LinkUrl = "",
                    CategoryId = 2,
                    IsOnSale = false
                },
                     new Decor
                     {
                         DecorId = 2,
                         Name = "Plush Reading Socks",
                         Description = "Everybody gets cold feet in the winter. Not anymore, with these incredibly warm and toast mid-calf socks. Your toes will thank you!",
                         Price = 16.99m,
                         Stock = 45,
                         Image = "/images/reading-socks.jpg",
                         LinkUrl = "",
                         CategoryId = 2,
                         IsOnSale = false
                     },
                          new Decor
                          {
                              DecorId = 3,
                              Name = "Reading Shaw",
                              Description = "Cozy shaw to wrap yourself in. Includes deep pockets. And sealed arm holes so it stays on. ",
                              Price = 24.99m,
                              Stock = 18,
                              Image = "/images/wearable-blanket.jpg",
                              LinkUrl = "",
                              CategoryId = 2,
                              IsOnSale = false


                          },
                              new Decor
                              {
                                  DecorId = 4,
                                  Name = "Edgar Allen Poe's Library Candle",
                                  Description = "Light this comforting candle next time you sit down to read. Smells like rich warm leather, smoky woods, amber and vanilla. Close your eyes you might find yourself transport to Mr Poe's library. ",
                                  Price = 24.99m,
                                  Stock = 35,
                                  Image = "/images/edward-candle.jpg",
                                  LinkUrl = "",
                                  CategoryId = 2,
                                  IsOnSale = false
                              },
                                 new Decor
                                 {
                                     DecorId = 5,
                                     Name = "Candle Warming Lamp",
                                     Description = "Revitalize your home and reading experience with this candle warming lamp. Releases sent with a flame, soot, or polluntants. Combines wood, glass and gold finish. ",
                                     Price = 34.99m,
                                     Stock = 23,
                                     Image = "/images/candle-warming-lamp.jpg",
                                     LinkUrl = "",
                                     CategoryId = 2,
                                     IsOnSale = false
                                 },

                                    new Decor
                                    {
                                        DecorId = 6,
                                        Name = "Wooden Book Caddy",
                                        Description = "This acacia wood book stand is perfect for keeping your reading glasses, phone and drinks within reach during your reading experience. Keep your page marked and your book safely stored.",
                                        Price = 24.99m,
                                        Stock = 60,
                                        Image = "/images/book-caddy.jpg",
                                        LinkUrl = "",
                                        CategoryId = 2,
                                        IsOnSale = false
                                    },

                                      new Decor
                                      {
                                          DecorId = 7,
                                          Name = "Amethyst Crystal Book End",
                                          Description = "Known for its calming and soothing properties. This heavy duty book will keep your books from failing and add great decor to all your shelves (or wherever else you like to store your books- HINT: Everywhere!).",
                                          Price = 69.99m,
                                          Stock = 20,
                                          Image = "/images/bookend.jpg",
                                          LinkUrl = "",
                                          CategoryId = 2,
                                          IsOnSale = false
                                      },
                                        new Decor
                                        {
                                            DecorId = 8,
                                            Name = "Mindful Texture Sand Garden",
                                            Description = "Practice mindfullness with this sand garden. Make patterns in the sand by rolling or raking the included miniature rake or groove rock. ",
                                            Price = 25.99m,
                                            Stock = 13,
                                            Image = "/images/Home-Mindful_Garden.jpg",
                                            LinkUrl = "",
                                            CategoryId = 2,
                                            IsOnSale = false
                                        },
                                           new Decor
                                           {
                                               DecorId = 9,
                                               Name = "Glass Globe Paperweight",
                                               Description = "Miniature globe paperweight. If you need a confidence boost, you can literally hold the world in your hands. Rotates 360 degrees. Beautiful for your office, desk, or bookshelf. ",
                                               Price = 29.99m,
                                               Stock = 11,
                                               Image = "/images/world-globe.jpg",
                                               LinkUrl = "",
                                               CategoryId = 2,
                                               IsOnSale = false
                                           },
                                              new Decor
                                              {
                                                  DecorId = 10,
                                                  Name = "Book Lover's Reading Light",
                                                  Description = "Clip on reading light, lightweight enough to not weight down your book and fit in your bag. Don't let the dark keep you from reading! Take AAA batteries",
                                                  Price = 14.99m,
                                                  Stock = 20,
                                                  Image = "/images/reading-light.jpg",
                                                  LinkUrl = "",
                                                  CategoryId = 2,
                                                  IsOnSale = false
                                              },
                                                 new Decor
                                                 {
                                                     DecorId = 11,
                                                     Name = "Novel Nook Exclusive Tote",
                                                     Description = "100% organic cotton Canvas bag with a reinforced base, a pocket for valuables, and a loop for keys. Comes with a Novel Nook exclusively currated print. Come prepared and carry your books everywhere.",
                                                     Price = 34.99m,
                                                     Stock = 60,
                                                     Image = "/images/tote-page.jpg",
                                                     LinkUrl = "",
                                                     CategoryId = 2,
                                                     IsOnSale = false
                                                 },

                                                    new Decor
                                                    {
                                                        DecorId = 12,
                                                        Name = "Novel Nook Exclusive Candle Set",
                                                        Description = "Introducing our own set of 3 candles specifically currated with our customers in mind. The smells include: Frosted Pine, Old Books, and Echanted Forest. Light one or all three.",
                                                        Price = 39.99m,
                                                        Stock = 22,
                                                        Image = "/images/candle-pack.jpg",
                                                        LinkUrl = "",
                                                        CategoryId = 2,
                                                        IsOnSale = false
                                                    },
                                                       new Decor
                                                       {
                                                           DecorId = 13,
                                                           Name = "Large Book Vase-Pride and Prejudice",
                                                           Description = "Fill this ceramic vase with your favorite fresh flowers or store your utensils. Adorn your kitchen, or any space you wish with some bookish charm.8in tall and 6 in long. A great gift for the Pride and Predujice fan in your life.",
                                                           Price = 24.99m,
                                                           Stock = 7,
                                                           Image = "/images/PP-vase.jpg",
                                                           LinkUrl = "",
                                                           CategoryId = 2,
                                                           IsOnSale = false
                                                       },
                                                          new Decor
                                                          {
                                                              DecorId = 14,
                                                              Name = "Black Leather Journal with Closure",
                                                              Description = "Beautiful black smooth calfskin leather jounral with snap closure and a gray ribbon bookmark. 150 ivory, worn edge  85 gsm pages",
                                                              Price = 29.99m,
                                                              Stock = 12,
                                                              Image = "/images/leather-journal.jpg",
                                                              LinkUrl = "",
                                                              CategoryId = 2,
                                                              IsOnSale = false
                                                          },

                                                             new Decor
                                                             {
                                                                 DecorId = 15,
                                                                 Name = "Leatherette Corner Bookmarks",
                                                                 Description = "Make your reading experience more classy with these real leather and gold embossed corner book mars. 2 pack. A elegant addition to saving your spot in reading.",
                                                                 Price = 9.99m,
                                                                 Stock = 20,
                                                                 Image = "/images/leather-bookmark.jpg",
                                                                 LinkUrl = "",
                                                                CategoryId = 2,
                                                                IsOnSale= false
                                                          });


            modelBuilder.Entity<Discussion>().HasData(
                  new Discussion
                  {
                      Id = 1,
                      Author = "Leslye Walton",
                      Title = "The Strange and Beautiful Sorrows of Ava Lavender",
                      OpinionField = "The writing is so beautiful. I found myself getting emotional while reading. The story is so incredibly atmospheric and moody. You will smile and have your heart broken in the same sentence. It really is a strange and beautiful book as the title suggest. It is about the painful and beautiful aspect of humanity we all must walk.",
                      Genre = "Fiction",
                      Review = 5
                  },
                     new Discussion
                     {
                         Id = 2,
                         Author = "Blake Crouch",
                         Title = "Dark Matter",
                         OpinionField = "This book made me feel tiny. It was overwhelming and scary, but oh so very gripping!\r\n\r\nDark Matter is the kind of compelling \"I must know WTF is going on\" book that makes you forget about everything else you had to do that day. You step into this world - this absolute mind trip of a world that will tug at both your heart strings and your brain cells - and you don't want to come out until you know how it ends. Real life? Who cares? Shit is going down and I need answers!.",
                         Genre = "Fiction",
                         Review = 5
                     });

//Sales-Clearance
            modelBuilder.Entity<Sale>().HasData(
                new Sale
                {
                    SaleId = 1,
                    SaleItemName = "Wish you were here",
                    SaleDescription = "Hard Cover - Gently used book. No marking or tears.",
                    SalePrice = 9.99m,
                    ImageUrl = "/Images/Wish-you-were-here.jpg",
                    IsOnSale = true
                },
                  new Sale
                  {
                      SaleId = 2,
                      SaleItemName = "Atlas of the Heart",
                      SaleDescription = "Hard Cover - Brand New-take a journey into your heart",
                      SalePrice = 14.99m,
                      ImageUrl ="/Images/Atlas-Heart.jpg",
                      IsOnSale = true
                  },
                    new Sale
                    {
                        SaleId = 3,
                        SaleItemName = "Sisters",
                        SaleDescription = "Hard Cover - Like New- floor model book",
                        SalePrice = 7.99m,
                        ImageUrl ="/Images/sisters-book.jpg",
                        IsOnSale = true
                    },
                      new Sale
                      {
                          SaleId = 4,
                          SaleItemName = "Goosebumps",
                          SaleDescription = "Soft Cover - Used-may contain a couple marks or creases, nothing obstructive",
                          SalePrice = 4.99m,
                          ImageUrl = "/Images/goosebumps.jpg",
                          IsOnSale = true
                      },
                      new Sale
                      {
                          SaleId = 5,
                          SaleItemName = "A Court of Silver Flames",
                          SaleDescription = "Hard Cover - New - floor model book",
                          SalePrice = 15.99m,
                          ImageUrl= "/Images/court-silver-flames.jpg",
                          IsOnSale = true
                      },
                          new Sale
                      {
                          SaleId = 6,
                          SaleItemName = "Thumb Book Holder",
                          SaleDescription = "6 pack. Variety of different stones. Easily hold your book open with these beautiful stone-crafted thumb page openers",
                          SalePrice = 30.99m,
                          ImageUrl="Images/Book-Thumb.jpg",
                          IsOnSale = true
                      },
                          new Sale
                      {
                          SaleId = 7,
                          SaleItemName = "The Very Hungry Catepillar",
                          SaleDescription = "Hard Cover- Like new",
                          SalePrice = 6.99m,
                          ImageUrl = "/Images/Hungry-Caterpillar.jpg",
                          IsOnSale = true
                      },
                          
                          
                          new Sale
                      {
                          SaleId = 8,
                          SaleItemName = "Outsiders",
                          SaleDescription = "Soft Cover -  Good condition - no creases, tears, or highlighting",
                          SalePrice = 6.99m,
                          ImageUrl = "/Images/Outsiders-Book.jpg",
                          IsOnSale = true
                      },
                         new Sale
                      {
                          SaleId = 9,
                          SaleItemName = "James and the Giant Peach",
                          SaleDescription = "Soft Cover - New - Classic",
                          SalePrice = 5.99m,
                          ImageUrl= "/Images/James-Giant-Peach.jpg",
                          IsOnSale = true
                      },
                         
                         new Sale
                      {
                          SaleId = 10,
                          SaleItemName = "Book Wreath",
                          SaleDescription = "Beautiful hand crafted wreath made form recycled book pages",
                          SalePrice = 39.99m,
                          ImageUrl = "/Images/Book-Wreath.jpg",
                          IsOnSale = true
                      });

              } 
        }
    }

