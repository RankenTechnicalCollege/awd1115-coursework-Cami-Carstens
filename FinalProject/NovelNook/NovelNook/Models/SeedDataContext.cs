using Microsoft.EntityFrameworkCore;

namespace NovelNook.Models
{
    public class SeedDataContext : DbContext
    {
        public SeedDataContext(DbContextOptions<SeedDataContext> options) : base(options) { }
        public DbSet<ExploreCard> ExploreCards { get; set; } = null!;
        public DbSet<BookRecommendation> BookRecommendations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookRecommendation>().HasData(
                new BookRecommendation
                {
                    Id = 1,
                    Title = "Dark Matter",
                    Author = "Blake Crouch",
                    Description = "A mind-bending thriller that explores the concept of alternate realities and the choices that define us. Jason Dessen, a college physics professor, is abducted and wakes up in a world where his life is completely different. As he navigates this new reality, he must confront the consequences of his choices and fight to return to his original life."

                },
                new BookRecommendation
                {
                    Id = 2,
                    Title = "Cold Tangerines: Celebrating the Extraordinary Nature of Everyday Life",
                    Author = "Shauna Niequist",
                    Description = "A collection of essays that find beauty and meaning in the ordinary moments of life. Shauna Niequist shares her reflections on family, faith, and the simple joys that make life special, encouraging readers to appreciate the small things that often go unnoticed."
                },
                new BookRecommendation
                {
                    Id = 3,
                    Title = "I'll give you the sun",
                    Author = "Jandy Nelson",
                    Description = "A young adult novel that tells the story of twins Noah and Jude, who are struggling to reconnect after a tragic event. The narrative alternates between their perspectives, revealing their secrets, dreams, and the complexities of their relationship as they navigate love, loss, and self-discovery."
                },
                new BookRecommendation
                {
                    Id = 4,
                    Title = "The Book of You",
                    Author = "Claire Kendal",
                    Description = "A psychological thriller that delves into the dark side of obsession and the lengths people will go to protect their secrets."
                },
                new BookRecommendation
                {
                    Id = 5,
                    Title = "Big Little Lies",
                    Author = "Liane Moriarty",
                    Description = "A gripping novel that explores the lives of three women in a tight-knit community, unraveling the secrets and lies that lead to a shocking event at a school trivia night."
                },
                new BookRecommendation
                {
                    Id = 6,
                    Title = "You",
                    Author = "Caroline Kepnes",
                    Description = "A psychological thriller that follows Joe Goldberg, a bookstore manager who becomes infatuated with a customer named Beck. The story is told from Joe's perspective, revealing his obsessive and dangerous behavior as he manipulates those around him to win Beck's affection."
                },
                new BookRecommendation
                {
                    Id = 7,
                    Title = "Scythe",
                    Author = "Neal Shusterman",
                    Description = "In a future where death has been conquered, two teenagers are chosen to become Scythes, the only ones who can end life to control population growth. As they learn the art of gleaning, they must navigate moral dilemmas and the corrupt world of the Scythedom."
                },
                new BookRecommendation
                {
                    Id = 8,
                    Title = "Vicious",
                    Author = "V.E. Schwab",
                    Description = "Vicious is a science fiction fantasy novel about two former college roommates, Victor Vale and Eli Ever, who turn into powerful arch-nemeses. After a shared research project goes horribly wrong, the two rivals develop extraordinary abilities and embark on a path of ambition, betrayal, and revenge. The story explores what happens when people gain superpowers in a world where there are no true heroes, only villains and anti-heroes with twisted motivations."
                },
                new BookRecommendation
                {
                    Id = 9,
                    Title = "Notes on Nervous Planet",
                    Author = "Matt Haig",
                    Description = "In Notes on a Nervous Planet, Matt Haig explores the impact of modern life on mental health, addressing issues like anxiety, social media, and the fast pace of contemporary living. Through personal anecdotes and reflections, Haig offers insights and practical advice on how to navigate the challenges of the digital age while maintaining mental well-being."
                },
                new BookRecommendation
                {
                    Id = 10,
                    Title = "Dig",
                    Author = "A.S. King",
                    Description = "Dig is a young adult novel that follows the story of a teenage girl named Brynn, who is struggling to cope with the recent death of her father. As she navigates her grief, Brynn uncovers family secrets and confronts her own identity, leading to a journey of self-discovery and healing."
                },
                new BookRecommendation
                {
                    Id = 11,
                    Title = "Everyday Amazing: Fascinating Facts About the Science That Surrounds Us",
                    Author = "Beatrice the Biologist",
                    Description = "Everyday Amazing is a fascinating exploration of the science behind everyday phenomena. Beatrice the Biologist delves into the wonders of the natural world, explaining complex scientific concepts in an engaging and accessible way. From the chemistry of cooking to the physics of rainbows, this book reveals the extraordinary science that surrounds us in our daily lives."
                },
                new BookRecommendation
                {
                    Id = 12,
                    Title = "Think Again",
                    Author = "Adam Grant",
                    Description = "Think Again: The Power of Knowing What You Don't Know by Adam Grant is about the importance of reexamining your beliefs and unlearning outdated knowledge to adapt and succeed in a rapidly changing world. Grant, an organizational psychologist, argues that what matters more than intelligence is \"mental flexibility\" and the willingness to question your own opinions."

                }
 );










            //Explore Cards on Explore Page

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ExploreCard>().HasData(
                new ExploreCard
                {
                    Id = 1,
                    Title = "Blood Over Bright Haven",
                    Description = "Magic has made the city of Tiran an industrial utopia, but magic has a cost. A dark academia brimming with mystery, tradegy, bravery, and damning echoes of the past. Through their fractious relationship, mage and outsider uncover an ancient secret that could change the course of magic forever—if it doesn’t get them killed first. Sciona has defined her life by the pursuit of truth, but how much is one truth worth with the fate of civilization in the balance?",
                    Author = "M.L. Wang",
                    Image = "/images/Blood-over-bright-haven.jpg",
                    LinkUrl = "https://www.amazon.com/dp/B0CVLFJMV2/?bestFormat=true&k=blood%20over%20bright%20haven&ref_=nb_sb_ss_w_scx-ent-pd-bk-d_k0_1_10_de&crid=1XVACO1WQC5QV&sprefix=blood%20%20over"
                },
                new ExploreCard
                {
                    Id = 2,
                    Title = "Artificial Intelligence for Dummies",
                    Description = "A comprehensive guide for non-technical users. Artificial intelligence (AI) is the science of creating computer systems that can perform tasks normally requiring human intelligence, such as learning, reasoning, and problem-solving. ",
                    Author = "John Paul Mueller, Luca Massaron, Stephanie Diamond",
                    Image = "/images/Ai-Dummies.jpg",
                    LinkUrl = "https://www.amazon.com/Artificial-Intelligence-Dummies-John-Mueller-ebook/dp/B0DK8MXGVY/ref=sr_1_2?crid=398YM8TX5WG2X&dib=eyJ2IjoiMSJ9.O1MzbnF2WLxv7V74eaqHLMv2xSdWdVHIS_p5LFuqXTqFaE4mQNBTkzRVDUeJ-5jgRR9YNGQ-5UQuDMnnLHDcqcT9KdGfhEIHNvw_vzIyTDOAD7q8Jkc5QOo9vPXJfOxLXPpJpf8yQ7YqC0jsXpbQxzCE4cbXmKRZxw7H-l6fzXFGePIUNkxAQuZnYI8KUeCuoxBMWeNpzUaaUEXb2KoLEff35KYjJkR3vRA5BH70C-Y.oFTZLJkPu8EcKrYWzWtbogzuuhYR9rcs-ue8RjyhYFw&dib_tag=se&keywords=ai+for+dummies+2025&qid=1758747855&s=digital-text&sprefix=Ai+for+%2Cdigital-text%2C131&sr=1-2"
                },

            new ExploreCard
            {
                Id = 3,
                Title = "All About Love",
                Description = "All About Love: New Visions, bell hooks argues that love is not simply a feeling but a conscious, intentional choice. Hooks's central thesis is that \"love is as love does\". She explains that modern society has fundamentally misunderstood love by treating it as a noun—a mystical, passive emotion—rather than a verb, which implies intentional action and will.",
                Author = "Bell Hooks",
                Image = "/images/all-about-love.jpg",
                LinkUrl = ""
            },

              new ExploreCard
              {
                  Id = 4,
                  Title = "murach's ASP.NET Core MVC",
                  Description = "Learn to write your first apps using MVC (Model-View-Controller) pattern. This book gets you off to a fast start whether or not you have prior experience with server-side development.\r\nIt teaches you all the skills you need to develop bulletproof, database-driven web apps. That includes using endpoint routing, Razor views, model binding, data validation, dependency injection, Bootstrap for responsive design, EF (Entity Framework) Core for database handling, xUnit and Moq for unit testing, and Identity for authentication",
                  Author = "Mary Delamater Joel Murach",
                  Image = "/images/ASPNet.jpg",
                  LinkUrl = ""
              },
                 new ExploreCard
                 {
                     Id = 5,
                     Title = "Be Water My Friend",
                     Description = " \"Empty your mind, be formless, shapeless—like water,\" was popularized by martial arts legend and philosopher Bruce Lee. The phrase is a core tenet of his philosophy, urging practitioners to become adaptable and fluid, both in combat and in life. \"Empty your mind, be formless, shapeless—like water. You put water into a cup, it becomes the cup. You put water into a bottle, it becomes the bottle. You put it in a teapot, it becomes the teapot. Now, water can flow or it can crash. Be water, my friend.",
                     Author = "Shannon Lee",
                     Image = "/images/Be-Water-My-Friend.jpg",
                     LinkUrl = ""
                 },
                 new ExploreCard
                 {
                     Id = 6,
                     Title = "Chainsaw Man Vol. 1",
                     Description = "Chainsaw Man, Vol. 1 introduces readers to Denji, a poor young man struggling with debt and despair. After being killed in a job, he is revived by his pet devil, Pochita, and transforms into Chainsaw Man, a powerful being with chainsaw-like abilities. The story follows Denji's journey as he seeks redemption and fights against devils, embodying humanity's darkest fears. The volume explores themes of hope, love, and the struggle for a better life, showcasing Denji's transformation and the bond he forms with Pochita. Denji is a small-time devil hunter just trying to survive in a harsh world. After being killed on a job, he is revived by his pet devil Pochita and becomes something new and dangerous—Chainsaw Man!",
                     Author = "Tatsuki Fujimoto",
                     Image = "/images/Chainsaw-man.jpg",
                     LinkUrl = ""
                 },
                 new ExploreCard
                 {
                     Id = 7,
                     Title = "Charlotte's Web",
                     Description = "Charlotte's Web is a classic 1952 children's novel by E.B. White about the unlikely friendship between a pig named Wilbur and a wise barn spider named Charlotte, who saves his life by spinning words in her web that praise him, preventing him from becoming pork chops. ",
                     Author = "E.B. White",
                     Image = "/images/Charlottes-web.jpg",
                     LinkUrl = ""
                 },
                 new ExploreCard
                 {
                     Id = 8,
                     Title = "Cinder",
                     Description = "Cinder by Marissa Meyer is the first book in The Lunar Chronicles, a young adult science fiction series that retells classic fairy tales in a futuristic, post-war world. The story follows Cinder, a cyborg mechanic in futuristic New Beijing, who is a second-class citizen with a hidden, mysterious past. When her life becomes entangled with Prince Kai, she finds herself at the center of an interplanetary struggle and a fight for Earth's survival against the tyrannical Queen Levana of the Lunar colony",
                     Author = "Marissa Meyer",
                     Image = "/images/Cinder.jpg",
                     LinkUrl = ""
                 },
                 new ExploreCard
                 {
                     Id = 9,
                     Title = "The Courage to be Disliked",
                     Description = "Having the courage to be disliked\" means accepting that you may face disapproval or criticism because you are living authentically and according to your own values, rather than trying to please others or conform to their expectations. It is the freedom to act according to your own beliefs and principles, even if it leads to rejection, and is seen as a pathway to genuine freedom and self-confidence",
                     Author = "Ichiro Kishimi and Fumitake Koga",
                     Image = "/images/courage-disliked.jpg",
                     LinkUrl = ""
                 },
                  new ExploreCard
                  {
                      Id = 10,
                      Title = "A Darker Shade of Magic",
                      Description = "A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force",
                      Author = "V.E. Schwab",
                      Image = "/images/Darker-shade-of-magic.jpg",
                      LinkUrl = ""
                  },
                  new ExploreCard
                  {
                      Id = 11,
                      Title = "Dark Matter",
                      Description = "A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force",
                      Author = "Blake Crouch",
                      Image = "/images/Dark-matter.jpg",
                      LinkUrl = ""
                  },
                   new ExploreCard
                   {
                       Id = 12,
                       Title = "Emotional Intelligence",
                       Description = "a groundbreaking book that argues emotional intelligence (EI), encompassing self-awareness, impulse control, persistence, empathy, and social skills, is a more significant determinant of success than IQ. Drawing on psychology and neuroscience, the book explains how EI, which can be nurtured and developed, influences relationships, career success, and overall well-being, offering a new understanding of intelligence and a compelling vision for personal and societal growth.  ",
                       Author = "Daniel Goleman",
                       Image = "/images/Emotional-intelligence.jpg",
                       LinkUrl = ""
                   },
                  new ExploreCard
                  {
                      Id = 13,
                      Title = "Erasing History",
                      Description = "In Erasing History, Yale professor of philosophy Jason Stanley exposes the true danger of the authoritarian right’s attacks on education, identifies their key tactics and funders, and traces their intellectual roots. He illustrates how fears of a fascist future have metastasized, from hypothetical threat to present reality. And with his “urgent, piercing, and altogether brilliant” (Johnathan M. Metzl, author of What We’ve Become) insight, he illustrates that hearts and minds are won in our schools and universities—places that democratic societies across the world are now ill-prepared to defend against the fascist assault currently underway",
                      Author = "Jason Stanley",
                      Image = "/images/Erasing-history.jpg",
                      LinkUrl = ""
                  },
                new ExploreCard
                {
                    Id = 14,
                    Title = "Golden Son",
                    Description = "Golden Son is the second novel in Pierce Brown's Red Rising Saga and follows Darrow as he continues his mission to destroy the Gold ruling class from within by becoming a leader among them after transforming from a lowborn Red to a Gold. The story expands on the political intrigue, betrayal, and warfare of the first book, with Darrow navigating treacherous alliances, growing his power, and preparing for a full-scale rebellion against the oppressive Society. \r\n",
                    Author = "Pierce Brown",
                    Image = "/images/Golden-son.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 15,
                    Title = "The Handmaid's Tale",
                    Description = "The Handmaid's Tale by Margaret Atwood is a dystopian novel published in 1985. Set in the near-future Republic of Gilead (formerly the United States), it follows Offred, a Handmaid whose sole purpose is to bear children for the ruling class. After environmental disasters cause a drastic drop in the birth rate, the totalitarian, patriarchal regime strips women of their rights and assigns them to specific social classes",
                    Author = "Margeret Atwood",
                    Image = "/images/handmaid-tale.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 16,
                    Title = "Kindness is my Superpower",
                    Description = "Kindness Is My Superpower is a children's book by Alicia Ortego that teaches young readers about empathy and compassion through the story of a boy named Lucas, who learns to make kindness his superpower. The book illustrates how simple acts like saying \"please\" and \"thank you,\" sharing, helping others, and apologizing can significantly impact others and create a positive environment. Through a heartwarming narrative, children learn that kindness, though sometimes challenging, is a source of inner strength and a powerful way to connect with the world around them",
                    Author = "Alicia Ortego",
                    Image = "/images/Kindness-is-My-Superpower.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 17,
                    Title = "Leadership for Dummies",
                    Description = "Leadership For Dummies is a practical guide that aims to teach anyone how to become a more effective leader, regardless of their current position or experience. The book moves beyond theory to provide hands-on strategies and techniques for developing leadership skills, building strong teams, and inspiring trust in others",
                    Author = "Marshall Loeb, Stephen Kindel",
                    Image = "/images/Leadership-Dummies.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 18,
                    Title = "All the Light We Cannot See",
                    Description = "All the Light We Cannot See is a Pulitzer Prize-winning novel by Anthony Doerr that tells the parallel stories of a blind French girl and a German orphan boy during World War II. Their paths converge in the besieged French town of Saint-Malo as both struggle to survive the devastation of the war. ",
                    Author = "Anthony Doer",
                    Image = "/images/Light-we-cannot-see.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 19,
                    Title = "Originals",
                    Description = "Originals: How Non-Conformists Move the World by Adam Grant is a book that explores how to champion new and novel ideas, identify good ideas, speak up without being silenced, and build coalitions to bring disruptive concepts to life. Through stories and studies from various fields, Grant details the qualities of original people, provides tips for nurturing originality in children and leaders, and examines how fear and doubt can be managed on the path to innovation",
                    Author = "Adam Grant",
                    Image = "/images/Originals.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 20,
                    Title = "People's History of the United States",
                    Description = "A People's History of the United States is a 1980 nonfiction book by historian Howard Zinn that tells the history of the country \"from the bottom up\". Zinn's work presents a different perspective than traditional narratives, focusing on the stories and struggles of marginalized groups rather than the powerful elites.",
                    Author = "Howards Zinn",
                    Image = "/images/Peoples-history.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 21,
                    Title = "Pretty Girls",
                    Description = "Karin Slaughter's psychological thriller Pretty Girls centers on estranged sisters Claire and Lydia, who are forced to confront their family's devastating past when a new tragedy strikes. The book deals with themes of family trauma, secrets, and the nature of survival.",
                    Author = "Karin Slaughter",
                    Image = "/images/Pretty-girls.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 22,
                    Title = "Python Programming",
                    Description = " Python programming aimed at beginners. His books focus on a practical, hands-on approach to learning Python and often include real-world projects and exercises to help solidify understanding",
                    Author = "Mark Reed",
                    Image = "/images/Python.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 23,
                    Title = "Red Rising",
                    Description = "Red Rising, written by Pierce Brown, is a science fiction novel that introduces a color-coded caste system where different classes of humanity occupy specific roles across the solar system. The story follows Darrow, a lowborn \"Red,\" who discovers the truth behind the oppressive society and embarks on a mission of vengeance and rebellion",
                    Author = "Pierce Brown",
                    Image = "/images/Red-rising.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 24,
                    Title = "The Silent Patient",
                    Description = "The Silent Patient is a 2019 psychological thriller novel by Alex Michaelides about a psychotherapist who becomes obsessed with unraveling the mystery of his patient, a famous artist who has gone completely silent after murdering her husband",
                    Author = "Alex Michaelides",
                    Image = "/images/Silent-patient.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 25,
                    Title = "Think Again",
                    Description = "Think Again: The Power of Knowing What You Don't Know by Adam Grant is about the importance of reexamining your beliefs and unlearning outdated knowledge to adapt and succeed in a rapidly changing world. Grant, an organizational psychologist, argues that what matters more than intelligence is \"mental flexibility\" and the willingness to question your own opinions.",
                    Author = "Adam Grant",
                    Image = "/images/Think-again.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 26,
                    Title = "Vicious",
                    Description = "V. E. Schwab's Vicious is a science fiction fantasy novel about two former college roommates, Victor Vale and Eli Ever, who turn into powerful arch-nemeses. After a shared research project goes horribly wrong, the two rivals develop extraordinary abilities and embark on a path of ambition, betrayal, and revenge. The story explores what happens when people gain superpowers in a world where there are no true heroes, only villains and anti-heroes with twisted motivations.",
                    Author = "V.E. Schwab",
                    Image = "/images/Vicious.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 27,
                    Title = "My Friends",
                    Description= "Fredrik Backman's My Friends is a story that alternates between the past and present, focusing on four teenage friends who find solace in each other on a pier, and a young woman named Louisa 25 years later. The past timeline reveals the intense bond between the friends—Ted, Yor, Ali, and the artist—as they navigate difficult home lives, with the artist becoming a symbol of hope. The present timeline follows Louisa, who, after losing her own best friend, receives the artist's famous painting and embarks on a journey to uncover its story. Ultimately, the book is a story about friendship, art, grief, and human connection, exploring how a single summer can impact lives for decades to come",
                    Author = "Fredrik Backman",
                    Image = "/images/my-friends.jpg",
                    LinkUrl = ""
                },
                new ExploreCard
                {
                    Id = 28,
                    Title = "River Is Waiting",
                    Description = "Corby Ledbetter is struggling. New fatherhood, the loss of his job, and a growing secret addiction have thrown his marriage to his beloved Emily into a tailspin. And that's before he causes the tragedy that tears the family apart.\r\n\r\nSentenced to prison, Corby struggles to survive life on the inside, where he bears witness to frightful acts of brutality but also experiences small acts of kindness and elemental kinship with a prison librarian who sees his light and some of his fellow offenders, including a tender-hearted cellmate and a troubled teen desperate for a role model. Buoyed by them and by his mother's enduring faith in him, Corby begins to transcend the boundaries of his confinement, sustained by his hope that mercy and reconciliation might still be possible. Can his crimes ever be forgiven by those he loves?",
                    Author="Wally Lamb",
                    Image = "/images/river-is-waiting.jpg",
                    LinkUrl = "",
                },
                   new ExploreCard
                   {
                       Id = 29,
                       Title = "Everything Is Beautiful and Everything Hurts ",
                       Description = "The stunning debut novel by the winner of the Allen & Unwin Commercial Fiction Prize. If you loved Lessons in Chemistry and Eleanor Oliphant is Completely Fine, you will adore Everything is Beautiful and Everything Hurts.\r\n\r\nMickey Bloom: five foot tall, dyslexic, and bullied at school. Mickey knows she's nothing special. Until one day, she discovers running.\r\n\r\nMickey's new-found talent makes her realise she's everything she thought she wasn't - powerful, strong and special. But her success comes at a cost, and the relentless training and pressure to win leaves Mickey broken, her dream in tatters.Years later, when Mickey is working in a dead-end job with a drop-kick boyfriend, her mother becomes seriously ill. After nursing her, Mickey realises the only way she can overcome her grief - and find herself - is to run again.A chance encounter with a stranger sees Mickey re-ignite her dreams. The two women form an unbreakable bond, as Mickey is shown what it means to run in the right direction.An unforgettable debut novel about change, family and grit, and what it takes to achieve your dreams.'Everything is Beautiful and Everything Hurts plunges the reader into the gruelling world of the long distance runner - every pleasure, every pain. Shapiro deftly weaves the coming-of-age story of Mickey Bloom into a gripping account of adult Bloom running the Auckland Marathon. This is compelling storytelling that exposes the sacrifices - physical and emotional - demanded of our sporting elite. Chilling, yet ultimately heartwarming, it celebrates success without flinching from staring down its brutal costs. A sophisticated debut that will capture the racing hearts of its readers.' - Sue Orr, author of Loop Tracks",
                        Author = "Josie Shapiro",
                       Image = "/images/everything-beautiful-hurts.jpg",
                       LinkUrl = "",
                   },
                      new ExploreCard
                      {
                          Id = 30,
                          Title = "Animal Farm",
                          Description = "A farm is taken over by its overworked, mistreated animals. With flaming idealism and stirring slogans, they set out to create a paradise of progress, justice, and equality. Thus the stage is set for one of the most telling satiric fables ever penned –a razor-edged fairy tale for grown-ups that records the evolution from revolution against tyranny to a totalitarianism just as terrible.\r\nWhen Animal Farm was first published, Stalinist Russia was seen as its target. Today it is devastatingly clear that wherever and whenever freedom is attacked, under whatever banner, the cutting clarity and savage comedy of George Orwell’s masterpiece have a meaning and message still ferociously fresh.",
                           Author = "George Orwell",
                          Image = "/images/animal-farm.jpg",
                          LinkUrl = "",
                      }


            );
        }
    }
}
