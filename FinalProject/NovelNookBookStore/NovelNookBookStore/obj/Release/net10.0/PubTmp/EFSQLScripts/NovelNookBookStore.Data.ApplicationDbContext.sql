IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetRoles] (
        [Id] nvarchar(450) NOT NULL,
        [Name] nvarchar(256) NULL,
        [NormalizedName] nvarchar(256) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetUsers] (
        [Id] nvarchar(450) NOT NULL,
        [UserName] nvarchar(256) NULL,
        [NormalizedUserName] nvarchar(256) NULL,
        [Email] nvarchar(256) NULL,
        [NormalizedEmail] nvarchar(256) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Categories] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Categories] PRIMARY KEY ([CategoryId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Discussions] (
        [Id] int NOT NULL IDENTITY,
        [Author] nvarchar(max) NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Genre] nvarchar(max) NOT NULL,
        [OpinionField] nvarchar(max) NOT NULL,
        [Review] int NOT NULL,
        CONSTRAINT [PK_Discussions] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Sales] (
        [SaleId] int NOT NULL IDENTITY,
        [SaleItemName] nvarchar(max) NULL,
        [SalePrice] decimal(18,2) NOT NULL,
        [SaleDescription] nvarchar(max) NULL,
        [ImageUrl] nvarchar(max) NULL,
        [IsOnSale] bit NOT NULL,
        CONSTRAINT [PK_Sales] PRIMARY KEY ([SaleId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetRoleClaims] (
        [Id] int NOT NULL IDENTITY,
        [RoleId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetUserClaims] (
        [Id] int NOT NULL IDENTITY,
        [UserId] nvarchar(450) NOT NULL,
        [ClaimType] nvarchar(max) NULL,
        [ClaimValue] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetUserLogins] (
        [LoginProvider] nvarchar(128) NOT NULL,
        [ProviderKey] nvarchar(128) NOT NULL,
        [ProviderDisplayName] nvarchar(max) NULL,
        [UserId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
        CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetUserRoles] (
        [UserId] nvarchar(450) NOT NULL,
        [RoleId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
        CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [AspNetUserTokens] (
        [UserId] nvarchar(450) NOT NULL,
        [LoginProvider] nvarchar(128) NOT NULL,
        [Name] nvarchar(128) NOT NULL,
        [Value] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
        CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] int NOT NULL IDENTITY,
        [OrderDate] datetime2 NOT NULL,
        [UserId] nvarchar(450) NULL,
        [TotalAmount] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId]),
        CONSTRAINT [FK_Orders_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Books] (
        [BookId] int NOT NULL IDENTITY,
        [Title] nvarchar(max) NOT NULL,
        [Author] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Stock] int NOT NULL,
        [Image] nvarchar(max) NULL,
        [LinkUrl] nvarchar(max) NULL,
        [CategoryId] int NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        [IsOnSale] bit NOT NULL,
        CONSTRAINT [PK_Books] PRIMARY KEY ([BookId]),
        CONSTRAINT [FK_Books_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Decors] (
        [DecorId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [Stock] int NOT NULL,
        [Image] nvarchar(max) NULL,
        [LinkUrl] nvarchar(max) NULL,
        [CategoryId] int NOT NULL,
        [ImageUrl] nvarchar(max) NULL,
        [IsOnSale] bit NOT NULL,
        CONSTRAINT [PK_Decors] PRIMARY KEY ([DecorId]),
        CONSTRAINT [FK_Decors_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Product] (
        [ProductId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        [Price] decimal(18,2) NULL,
        [Stock] int NOT NULL,
        [CategoryId] int NOT NULL,
        [ImageUrl] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([ProductId]),
        CONSTRAINT [FK_Product_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([CategoryId]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [Review] (
        [ReviewId] int NOT NULL IDENTITY,
        [UserName] nvarchar(max) NOT NULL,
        [Rating] int NOT NULL,
        [OpinionField] nvarchar(max) NULL,
        [BookId] int NULL,
        [DecorId] int NULL,
        [ApplicationUserId] nvarchar(450) NULL,
        CONSTRAINT [PK_Review] PRIMARY KEY ([ReviewId]),
        CONSTRAINT [FK_Review_AspNetUsers_ApplicationUserId] FOREIGN KEY ([ApplicationUserId]) REFERENCES [AspNetUsers] ([Id]),
        CONSTRAINT [FK_Review_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]),
        CONSTRAINT [FK_Review_Decors_DecorId] FOREIGN KEY ([DecorId]) REFERENCES [Decors] ([DecorId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE TABLE [OrderItems] (
        [OrderItemId] int NOT NULL IDENTITY,
        [OrderId] int NULL,
        [BookId] int NULL,
        [DecorId] int NULL,
        [SaleItemId] int NULL,
        [Quantity] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        [DecorId1] int NULL,
        [ProductId] int NULL,
        CONSTRAINT [PK_OrderItems] PRIMARY KEY ([OrderItemId]),
        CONSTRAINT [FK_OrderItems_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([BookId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_OrderItems_Decors_DecorId] FOREIGN KEY ([DecorId]) REFERENCES [Decors] ([DecorId]) ON DELETE NO ACTION,
        CONSTRAINT [FK_OrderItems_Decors_DecorId1] FOREIGN KEY ([DecorId1]) REFERENCES [Decors] ([DecorId]),
        CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderItems_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([ProductId]),
        CONSTRAINT [FK_OrderItems_Sales_SaleItemId] FOREIGN KEY ([SaleItemId]) REFERENCES [Sales] ([SaleId])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] ON;
    EXEC(N'INSERT INTO [Categories] ([CategoryId], [Name])
    VALUES (1, N''Book''),
    (2, N''Home'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'CategoryId', N'Name') AND [object_id] = OBJECT_ID(N'[Categories]'))
        SET IDENTITY_INSERT [Categories] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'OpinionField', N'Review', N'Title') AND [object_id] = OBJECT_ID(N'[Discussions]'))
        SET IDENTITY_INSERT [Discussions] ON;
    EXEC(N'INSERT INTO [Discussions] ([Id], [Author], [Genre], [OpinionField], [Review], [Title])
    VALUES (1, N''Leslye Walton'', N''Fiction'', N''The writing is so beautiful. I found myself getting emotional while reading. The story is so incredibly atmospheric and moody. You will smile and have your heart broken in the same sentence. It really is a strange and beautiful book as the title suggest. It is about the painful and beautiful aspect of humanity we all must walk.'', 5, N''The Strange and Beautiful Sorrows of Ava Lavender''),
    (2, N''Blake Crouch'', N''Fiction'', CONCAT(CAST(N''This book made me feel tiny. It was overwhelming and scary, but oh so very gripping!'' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N''Dark Matter is the kind of compelling "I must know WTF is going on" book that makes you forget about everything else you had to do that day. You step into this world - this absolute mind trip of a world that will tug at both your heart strings and your brain cells - and you don''''t want to come out until you know how it ends. Real life? Who cares? Shit is going down and I need answers!.''), 5, N''Dark Matter'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Author', N'Genre', N'OpinionField', N'Review', N'Title') AND [object_id] = OBJECT_ID(N'[Discussions]'))
        SET IDENTITY_INSERT [Discussions] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SaleId', N'ImageUrl', N'IsOnSale', N'SaleDescription', N'SaleItemName', N'SalePrice') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] ON;
    EXEC(N'INSERT INTO [Sales] ([SaleId], [ImageUrl], [IsOnSale], [SaleDescription], [SaleItemName], [SalePrice])
    VALUES (1, N''/Images/Wish-you-were-here.jpg'', CAST(1 AS bit), N''Hard Cover - Gently used book. No marking or tears.'', N''Wish you were here'', 9.99),
    (2, N''/Images/Atlas-Heart.jpg'', CAST(1 AS bit), N''Hard Cover - Brand New-take a journey into your heart'', N''Atlas of the Heart'', 14.99),
    (3, N''/Images/sisters-book.jpg'', CAST(1 AS bit), N''Hard Cover - Like New- floor model book'', N''Sisters'', 7.99),
    (4, N''/Images/goosebumps.jpg'', CAST(1 AS bit), N''Soft Cover - Used-may contain a couple marks or creases, nothing obstructive'', N''Goosebumps'', 4.99),
    (5, N''/Images/court-silver-flames.jpg'', CAST(1 AS bit), N''Hard Cover - New - floor model book'', N''A Court of Silver Flames'', 15.99),
    (6, N''Images/Book-Thumb.jpg'', CAST(1 AS bit), N''6 pack. Variety of different stones. Easily hold your book open with these beautiful stone-crafted thumb page openers'', N''Thumb Book Holder'', 30.99),
    (7, N''/Images/Hungry-Caterpillar.jpg'', CAST(1 AS bit), N''Hard Cover- Like new'', N''The Very Hungry Catepillar'', 6.99),
    (8, N''/Images/Outsiders-Book.jpg'', CAST(1 AS bit), N''Soft Cover -  Good condition - no creases, tears, or highlighting'', N''Outsiders'', 6.99),
    (9, N''/Images/James-Giant-Peach.jpg'', CAST(1 AS bit), N''Soft Cover - New - Classic'', N''James and the Giant Peach'', 5.99),
    (10, N''/Images/Book-Wreath.jpg'', CAST(1 AS bit), N''Beautiful hand crafted wreath made form recycled book pages'', N''Book Wreath'', 39.99)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'SaleId', N'ImageUrl', N'IsOnSale', N'SaleDescription', N'SaleItemName', N'SalePrice') AND [object_id] = OBJECT_ID(N'[Sales]'))
        SET IDENTITY_INSERT [Sales] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'Author', N'CategoryId', N'Description', N'Image', N'ImageUrl', N'IsOnSale', N'LinkUrl', N'Price', N'Stock', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
        SET IDENTITY_INSERT [Books] ON;
    EXEC(N'INSERT INTO [Books] ([BookId], [Author], [CategoryId], [Description], [Image], [ImageUrl], [IsOnSale], [LinkUrl], [Price], [Stock], [Title])
    VALUES (1, N''James Clear'', 1, N''No matter your goals, Atomic Habits offers a proven framework for improving--every day. James Clear, one of the world''''s leading experts on habit formation, reveals practical strategies that will teach you exactly how to form good habits, break bad ones, and master the tiny behaviors that lead to remarkable results'', N''/images/atomic-habits.jpg'', NULL, CAST(0 AS bit), N'''', 18.99, 10, N''Atomic Habits''),
    (2, N''Shauna Niequist'', 1, N''A collection of essays that find beauty and meaning in the ordinary moments of life. Shauna Niequist shares her reflections on family, faith, and the simple joys that make life special, encouraging readers to appreciate the small things that often go unnoticed.'', N''/images/cold-tangerines.jpg'', NULL, CAST(0 AS bit), N'''', 16.99, 20, N''Cold Tangerines: Celebrating the Extraordinary Nature of Everyday Life''),
    (3, N''Jandy Nelson'', 1, N''A young adult novel that tells the story of twins Noah and Jude, who are struggling to reconnect after a tragic event. The narrative alternates between their perspectives, revealing their secrets, dreams, and the complexities of their relationship as they navigate love, loss, and self-discovery.'', N''/images/ill-give-you-the-sun.jpg'', NULL, CAST(0 AS bit), N'''', 14.99, 29, N''I''''ll give you the sun''),
    (4, N''Claire Kendal'', 1, N''A psychological thriller that delves into the dark side of obsession and the lengths people will go to protect their secrets.'', N''/images/book-of-you.jpg'', NULL, CAST(0 AS bit), N'''', 26.99, 3, N''The Book of You''),
    (5, N''Liane Moriarty'', 1, N''A gripping novel that explores the lives of three women in a tight-knit community, unraveling the secrets and lies that lead to a shocking event at a school trivia night.'', N''/images/big-little-lies.jpg'', NULL, CAST(0 AS bit), N'''', 26.99, 7, N''Big Little Lies''),
    (6, N''Caroline Kepnes'', 1, N''A psychological thriller that follows Joe Goldberg, a bookstore manager who becomes infatuated with a customer named Beck. The story is told from Joe''''s perspective, revealing his obsessive and dangerous behavior as he manipulates those around him to win Beck''''s affection.'', N''/images/you.jpg'', NULL, CAST(0 AS bit), N'''', 25.99, 3, N''You''),
    (7, N''Neal Shusterman'', 1, N''In a future where death has been conquered, two teenagers are chosen to become Scythes, the only ones who can end life to control population growth. As they learn the art of gleaning, they must navigate moral dilemmas and the corrupt world of the Scythedom.'', N''/images/scythe.jpg'', NULL, CAST(0 AS bit), N'''', 17.99, 3, N''Scythe''),
    (8, N''Stephen King'', 1, N''From legendary storyteller and master of short fiction Stephen King comes an extraordinary new collection of twelve short stories, many never-before-published, and some of his best EVER.'', N''/images/like-it-darker.jpg'', NULL, CAST(0 AS bit), N'''', 19.99, 5, N''You Like It Darker''),
    (9, N''Matt Haig'', 1, N''In Notes on a Nervous Planet, Matt Haig explores the impact of modern life on mental health, addressing issues like anxiety, social media, and the fast pace of contemporary living. Through personal anecdotes and reflections, Haig offers insights and practical advice on how to navigate the challenges of the digital age while maintaining mental well-being.'', N''/images/nervous-planet.jpg'', NULL, CAST(0 AS bit), N'''', 16.99, 7, N''Notes on Nervous Planet''),
    (10, N''A.S. King'', 1, N''Dig is a young adult novel that follows the story of a teenage girl named Brynn, who is struggling to cope with the recent death of her father. As she navigates her grief, Brynn uncovers family secrets and confronts her own identity, leading to a journey of self-discovery and healing.'', N''/images/dig.jpg'', NULL, CAST(0 AS bit), N'''', 18.99, 8, N''Dig''),
    (11, N''Beatrice the Biologist'', 1, N''Everyday Amazing is a fascinating exploration of the science behind everyday phenomena. Beatrice the Biologist delves into the wonders of the natural world, explaining complex scientific concepts in an engaging and accessible way. From the chemistry of cooking to the physics of rainbows, this book reveals the extraordinary science that surrounds us in our daily lives.'', N''/images/everyday-amazing.jpg'', NULL, CAST(0 AS bit), N'''', 16.99, 9, N''Everyday Amazing: Fascinating Facts About the Science That Surrounds Us''),
    (12, N''Rory Power'', 1, CONCAT(CAST(N''It''''s been eighteen months since the Raxter School for Girls was put under quarantine. Since the Tox hit and pulled Hetty''''s life out from under her.'' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N''It started slow. First the teachers died one by one. Then it began to infect the students, turning their bodies strange and foreign. Now, cut off from the rest of the world and left to fend for themselves on their island home, the girls don''''t dare wander outside the school''''s fence, where the Tox has made the woods wild and dangerous. They wait for the cure they were promised as the Tox seeps into everything.'', nchar(13), nchar(10), nchar(13), nchar(10), N''But when Byatt goes missing, Hetty will do anything to find her, even if it means breaking quarantine and braving the horrors that lie beyond the fence. And when she does, Hetty learns that there''''s more to their story, to their life at Raxter, than she could have ever thought true.''), N''/images/wilder-girls.jpg'', NULL, CAST(0 AS bit), N'''', 24.99, 22, N''Wilder Girls''),
    (13, N''M.L. Wang'', 1, N''Magic has made the city of Tiran an industrial utopia, but magic has a cost. A dark academia brimming with mystery, tradegy, bravery, and damning echoes of the past. Through their fractious relationship, mage and outsider uncover an ancient secret that could change the course of magic forever—if it doesn’t get them killed first. Sciona has defined her life by the pursuit of truth, but how much is one truth worth with the fate of civilization in the balance?'', N''/images/Blood-over-bright-haven.jpg'', NULL, CAST(0 AS bit), N'''', 22.99, 14, N''Blood Over Bright Haven''),
    (14, N''John Paul Mueller, Luca Massaron, Stephanie Diamond'', 1, N''A comprehensive guide for non-technical users. Artificial intelligence (AI) is the science of creating computer systems that can perform tasks normally requiring human intelligence, such as learning, reasoning, and problem-solving. '', N''/images/Ai-Dummies.jpg'', NULL, CAST(0 AS bit), N'''', 19.99, 17, N''Artificial Intelligence for Dummies''),
    (15, N''Bell Hooks'', 1, N''All About Love: New Visions, bell hooks argues that love is not simply a feeling but a conscious, intentional choice. Hooks''''s central thesis is that "love is as love does". She explains that modern society has fundamentally misunderstood love by treating it as a noun—a mystical, passive emotion—rather than a verb, which implies intentional action and will.'', N''/images/all-about-love.jpg'', NULL, CAST(0 AS bit), N'''', 14.99, 0, N''All About Love''),
    (16, N''Mary Delamater Joel Murach'', 1, CONCAT(CAST(N''Learn to write your first apps using MVC (Model-View-Controller) pattern. This book gets you off to a fast start whether or not you have prior experience with server-side development.'' AS nvarchar(max)), nchar(13), nchar(10), N''It teaches you all the skills you need to develop bulletproof, database-driven web apps. That includes using endpoint routing, Razor views, model binding, data validation, dependency injection, Bootstrap for responsive design, EF (Entity Framework) Core for database handling, xUnit and Moq for unit testing, and Identity for authentication''), N''/images/ASPNet.jpg'', NULL, CAST(0 AS bit), N'''', 59.5, 12, N''murach''''s ASP.NET Core MVC''),
    (17, N''Shannon Lee'', 1, N'' "Empty your mind, be formless, shapeless—like water," was popularized by martial arts legend and philosopher Bruce Lee. The phrase is a core tenet of his philosophy, urging practitioners to become adaptable and fluid, both in combat and in life. "Empty your mind, be formless, shapeless—like water. You put water into a cup, it becomes the cup. You put water into a bottle, it becomes the bottle. You put it in a teapot, it becomes the teapot. Now, water can flow or it can crash. Be water, my friend.'', N''/images/Be-Water-My-Friend.jpg'', NULL, CAST(0 AS bit), N'''', 16.99, 15, N''Be Water My Friend''),
    (18, N''Tatsuki Fujimoto'', 1, N''Chainsaw Man, Vol. 1 introduces readers to Denji, a poor young man struggling with debt and despair. After being killed in a job, he is revived by his pet devil, Pochita, and transforms into Chainsaw Man, a powerful being with chainsaw-like abilities. The story follows Denji''''s journey as he seeks redemption and fights against devils, embodying humanity''''s darkest fears. The volume explores themes of hope, love, and the struggle for a better life, showcasing Denji''''s transformation and the bond he forms with Pochita. Denji is a small-time devil hunter just trying to survive in a harsh world. After being killed on a job, he is revived by his pet devil Pochita and becomes something new and dangerous—Chainsaw Man!'', N''/images/Chainsaw-man.jpg'', NULL, CAST(0 AS bit), N'''', 11.99, 19, N''Chainsaw Man Vol. 1''),
    (19, N''E.B. White'', 1, N''Charlotte''''s Web is a classic 1952 children''''s novel by E.B. White about the unlikely friendship between a pig named Wilbur and a wise barn spider named Charlotte, who saves his life by spinning words in her web that praise him, preventing him from becoming pork chops. '', N''/images/Charlottes-web.jpg'', NULL, CAST(0 AS bit), N'''', 8.99, 23, N''Charlotte''''s Web''),
    (20, N''Marissa Meyer'', 1, N''Cinder by Marissa Meyer is the first book in The Lunar Chronicles, a young adult science fiction series that retells classic fairy tales in a futuristic, post-war world. The story follows Cinder, a cyborg mechanic in futuristic New Beijing, who is a second-class citizen with a hidden, mysterious past. When her life becomes entangled with Prince Kai, she finds herself at the center of an interplanetary struggle and a fight for Earth''''s survival against the tyrannical Queen Levana of the Lunar colony'', N''/images/Cinder.jpg'', NULL, CAST(0 AS bit), N'''', 12.99, 24, N''Cinder''),
    (21, N''Ichiro Kishimi and Fumitake Koga'', 1, N''Having the courage to be disliked" means accepting that you may face disapproval or criticism because you are living authentically and according to your own values, rather than trying to please others or conform to their expectations. It is the freedom to act according to your own beliefs and principles, even if it leads to rejection, and is seen as a pathway to genuine freedom and self-confidence'', N''/images/courage-disliked.jpg'', NULL, CAST(0 AS bit), N'''', 14.99, 17, N''The Courage to be Disliked''),
    (22, N''V.E. Schwab'', 1, N''A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force'', N''/images/Darker-shade-of-magic.jpg'', NULL, CAST(0 AS bit), N'''', 22.99, 2, N''A Darker Shade of Magic''),
    (23, N''Blake Crouch'', 1, N''A Darker Shade of Magic by V.E. Schwab is a fantasy novel about Kell, a rare magician called an Antari, who can travel between four parallel versions of London. He serves as an ambassador in the magical Red London but also works as a smuggler, leading to his accidental acquisition of a forbidden black stone from Black London. When an exchange goes wrong, Kell escapes to the non-magical Grey London, where he meets the cunning thief Lila Bard, and together they embark on a perilous adventure to save all the worlds from a greedy, magic-hungry force'', N''/images/Dark-matter.jpg'', NULL, CAST(0 AS bit), N'''', 19.99, 6, N''Dark Matter''),
    (24, N''Daniel Goleman'', 1, N''a groundbreaking book that argues emotional intelligence (EI), encompassing self-awareness, impulse control, persistence, empathy, and social skills, is a more significant determinant of success than IQ. Drawing on psychology and neuroscience, the book explains how EI, which can be nurtured and developed, influences relationships, career success, and overall well-being, offering a new understanding of intelligence and a compelling vision for personal and societal growth.  '', N''/images/Emotional-intelligence.jpg'', NULL, CAST(0 AS bit), N'''', 15.99, 9, N''Emotional Intelligence''),
    (25, N''Jason Stanley'', 1, N''In Erasing History, Yale professor of philosophy Jason Stanley exposes the true danger of the authoritarian right’s attacks on education, identifies their key tactics and funders, and traces their intellectual roots. He illustrates how fears of a fascist future have metastasized, from hypothetical threat to present reality. And with his “urgent, piercing, and altogether brilliant” (Johnathan M. Metzl, author of What We’ve Become) insight, he illustrates that hearts and minds are won in our schools and universities—places that democratic societies across the world are now ill-prepared to defend against the fascist assault currently underway'', N''/images/Erasing-history.jpg'', NULL, CAST(0 AS bit), N'''', 23.99, 10, N''Erasing History''),
    (26, N''Pierce Brown'', 1, CONCAT(CAST(N''Golden Son is the second novel in Pierce Brown''''s Red Rising Saga and follows Darrow as he continues his mission to destroy the Gold ruling class from within by becoming a leader among them after transforming from a lowborn Red to a Gold. The story expands on the political intrigue, betrayal, and warfare of the first book, with Darrow navigating treacherous alliances, growing his power, and preparing for a full-scale rebellion against the oppressive Society. '' AS nvarchar(max)), nchar(13), nchar(10)), N''/images/Golden-son.jpg'', NULL, CAST(0 AS bit), N'''', 19.99, 13, N''Golden Son''),
    (27, N''Margeret Atwood'', 1, N''The Handmaid''''s Tale by Margaret Atwood is a dystopian novel published in 1985. Set in the near-future Republic of Gilead (formerly the United States), it follows Offred, a Handmaid whose sole purpose is to bear children for the ruling class. After environmental disasters cause a drastic drop in the birth rate, the totalitarian, patriarchal regime strips women of their rights and assigns them to specific social classes'', N''/images/handmaid-tale.jpg'', NULL, CAST(0 AS bit), N'''', 11.99, 10, N''The Handmaid''''s Tale''),
    (28, N''Alicia Ortego'', 1, N''Kindness Is My Superpower is a children''''s book by Alicia Ortego that teaches young readers about empathy and compassion through the story of a boy named Lucas, who learns to make kindness his superpower. The book illustrates how simple acts like saying "please" and "thank you," sharing, helping others, and apologizing can significantly impact others and create a positive environment. Through a heartwarming narrative, children learn that kindness, though sometimes challenging, is a source of inner strength and a powerful way to connect with the world around them'', N''/images/Kindness-is-My-Superpower.jpg'', NULL, CAST(0 AS bit), N'''', 14.99, 0, N''Kindness is my Superpower''),
    (29, N''Marshall Loeb, Stephen Kindel'', 1, N''Leadership For Dummies is a practical guide that aims to teach anyone how to become a more effective leader, regardless of their current position or experience. The book moves beyond theory to provide hands-on strategies and techniques for developing leadership skills, building strong teams, and inspiring trust in others'', N''/images/Leadership-Dummies.jpg'', NULL, CAST(0 AS bit), N'''', 24.99, 10, N''Leadership for Dummies''),
    (30, N''Anthony Doer'', 1, N''All the Light We Cannot See is a Pulitzer Prize-winning novel by Anthony Doerr that tells the parallel stories of a blind French girl and a German orphan boy during World War II. Their paths converge in the besieged French town of Saint-Malo as both struggle to survive the devastation of the war. '', N''/images/Light-we-cannot-see.jpg'', NULL, CAST(0 AS bit), N'''', 22.99, 20, N''All the Light We Cannot See''),
    (31, N''Adam Grant'', 1, N''Originals: How Non-Conformists Move the World by Adam Grant is a book that explores how to champion new and novel ideas, identify good ideas, speak up without being silenced, and build coalitions to bring disruptive concepts to life. Through stories and studies from various fields, Grant details the qualities of original people, provides tips for nurturing originality in children and leaders, and examines how fear and doubt can be managed on the path to innovation'', N''/images/Originals.jpg'', NULL, CAST(0 AS bit), N'''', 22.99, 14, N''Originals''),
    (32, N''Howards Zinn'', 1, N''A People''''s History of the United States is a 1980 nonfiction book by historian Howard Zinn that tells the history of the country "from the bottom up". Zinn''''s work presents a different perspective than traditional narratives, focusing on the stories and struggles of marginalized groups rather than the powerful elites.'', N''/images/Peoples-history.jpg'', NULL, CAST(0 AS bit), N'''', 26.99, 0, N''People''''s History of the United States''),
    (33, N''Karin Slaughter'', 1, N''Karin Slaughter''''s psychological thriller Pretty Girls centers on estranged sisters Claire and Lydia, who are forced to confront their family''''s devastating past when a new tragedy strikes. The book deals with themes of family trauma, secrets, and the nature of survival.'', N''/images/Pretty-girls.jpg'', NULL, CAST(0 AS bit), N'''', 22.99, 15, N''Pretty Girls''),
    (34, N''Mark Reed'', 1, N'' Python programming aimed at beginners. His books focus on a practical, hands-on approach to learning Python and often include real-world projects and exercises to help solidify understanding'', N''/images/Python.jpg'', NULL, CAST(0 AS bit), N'''', 56.5, 17, N''Python Programming''),
    (35, N''Pierce Brown'', 1, N''Red Rising, written by Pierce Brown, is a science fiction novel that introduces a color-coded caste system where different classes of humanity occupy specific roles across the solar system. The story follows Darrow, a lowborn "Red," who discovers the truth behind the oppressive society and embarks on a mission of vengeance and rebellion'', N''/images/Red-rising.jpg'', NULL, CAST(0 AS bit), N'''', 19.99, 3, N''Red Rising''),
    (36, N''Alex Michaelides'', 1, N''The Silent Patient is a 2019 psychological thriller novel by Alex Michaelides about a psychotherapist who becomes obsessed with unraveling the mystery of his patient, a famous artist who has gone completely silent after murdering her husband'', N''/images/Silent-patient.jpg'', NULL, CAST(0 AS bit), N'''', 25.99, 7, N''The Silent Patient''),
    (37, N''Adam Grant'', 1, N''Think Again: The Power of Knowing What You Don''''t Know by Adam Grant is about the importance of reexamining your beliefs and unlearning outdated knowledge to adapt and succeed in a rapidly changing world. Grant, an organizational psychologist, argues that what matters more than intelligence is "mental flexibility" and the willingness to question your own opinions.'', N''/images/Think-again.jpg'', NULL, CAST(0 AS bit), N'''', 22.99, 8, N''Think Again''),
    (38, N''V.E. Schwab'', 1, N''V. E. Schwab''''s Vicious is a science fiction fantasy novel about two former college roommates, Victor Vale and Eli Ever, who turn into powerful arch-nemeses. After a shared research project goes horribly wrong, the two rivals develop extraordinary abilities and embark on a path of ambition, betrayal, and revenge. The story explores what happens when people gain superpowers in a world where there are no true heroes, only villains and anti-heroes with twisted motivations.'', N''/images/Vicious.jpg'', NULL, CAST(0 AS bit), N'''', 19.99, 9, N''Vicious''),
    (39, N''Fredrik Backman'', 1, N''Fredrik Backman''''s My Friends is a story that alternates between the past and present, focusing on four teenage friends who find solace in each other on a pier, and a young woman named Louisa 25 years later. The past timeline reveals the intense bond between the friends—Ted, Yor, Ali, and the artist—as they navigate difficult home lives, with the artist becoming a symbol of hope. The present timeline follows Louisa, who, after losing her own best friend, receives the artist''''s famous painting and embarks on a journey to uncover its story. Ultimately, the book is a story about friendship, art, grief, and human connection, exploring how a single summer can impact lives for decades to come'', N''/images/my-friends.jpg'', NULL, CAST(0 AS bit), N'''', 25.99, 19, N''My Friends''),
    (40, N''Wally Lamb'', 1, CONCAT(CAST(N''Corby Ledbetter is struggling. New fatherhood, the loss of his job, and a growing secret addiction have thrown his marriage to his beloved Emily into a tailspin. And that''''s before he causes the tragedy that tears the family apart.'' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N''Sentenced to prison, Corby struggles to survive life on the inside, where he bears witness to frightful acts of brutality but also experiences small acts of kindness and elemental kinship with a prison librarian who sees his light and some of his fellow offenders, including a tender-hearted cellmate and a troubled teen desperate for a role model. Buoyed by them and by his mother''''s enduring faith in him, Corby begins to transcend the boundaries of his confinement, sustained by his hope that mercy and reconciliation might still be possible. Can his crimes ever be forgiven by those he loves?''), N''/images/river-is-waiting.jpg'', NULL, CAST(0 AS bit), N'''', 26.99, 20, N''River Is Waiting''),
    (41, N''Josie Shapiro'', 1, CONCAT(CAST(N''The stunning debut novel by the winner of the Allen & Unwin Commercial Fiction Prize. If you loved Lessons in Chemistry and Eleanor Oliphant is Completely Fine, you will adore Everything is Beautiful and Everything Hurts.'' AS nvarchar(max)), nchar(13), nchar(10), nchar(13), nchar(10), N''Mickey Bloom: five foot tall, dyslexic, and bullied at school. Mickey knows she''''s nothing special. Until one day, she discovers running.'', nchar(13), nchar(10), nchar(13), nchar(10), N''Mickey''''s new-found talent makes her realise she''''s everything she thought she wasn''''t - powerful, strong and special. But her success comes at a cost, and the relentless training and pressure to win leaves Mickey broken, her dream in tatters.Years later, when Mickey is working in a dead-end job with a drop-kick boyfriend, her mother becomes seriously ill. After nursing her, Mickey realises the only way she can overcome her grief - and find herself - is to run again.A chance encounter with a stranger sees Mickey re-ignite her dreams. The two women form an unbreakable bond, as Mickey is shown what it means to run in the right direction.An unforgettable debut novel about change, family and grit, and what it takes to achieve your dreams.''''Everything is Beautiful and Everything Hurts plunges the reader into the gruelling world of the long distance runner - every pleasure, every pain. Shapiro deftly weaves the coming-of-age story of Mickey Bloom into a gripping account of adult Bloom running the Auckland Marathon. This is compelling storytelling that exposes the sacrifices - physical and emotional - demanded of our sporting elite. Chilling, yet ultimately heartwarming, it celebrates success without flinching from staring down its brutal costs. A sophisticated debut that will capture the racing hearts of its readers.'''' - Sue Orr, author of Loop Tracks''), N''/images/everything-beautiful-hurts.jpg'', NULL, CAST(0 AS bit), N'''', 16.99, 13, N''Everything Is Beautiful and Everything Hurts ''),
    (42, N''George Orwell'', 1, CONCAT(CAST(N''A farm is taken over by its overworked, mistreated animals. With flaming idealism and stirring slogans, they set out to create a paradise of progress, justice, and equality. Thus the stage is set for one of the most telling satiric fables ever penned –a razor-edged fairy tale for grown-ups that records the evolution from revolution against tyranny to a totalitarianism just as terrible.'' AS nvarchar(max)), nchar(13), nchar(10), N''When Animal Farm was first published, Stalinist Russia was seen as its target. Today it is devastatingly clear that wherever and whenever freedom is attacked, under whatever banner, the cutting clarity and savage comedy of George Orwell’s masterpiece have a meaning and message still ferociously fresh.''), N''/images/animal-farm.jpg'', NULL, CAST(0 AS bit), N'''', 9.99, 4, N''Animal Farm'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'BookId', N'Author', N'CategoryId', N'Description', N'Image', N'ImageUrl', N'IsOnSale', N'LinkUrl', N'Price', N'Stock', N'Title') AND [object_id] = OBJECT_ID(N'[Books]'))
        SET IDENTITY_INSERT [Books] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DecorId', N'CategoryId', N'Description', N'Image', N'ImageUrl', N'IsOnSale', N'LinkUrl', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Decors]'))
        SET IDENTITY_INSERT [Decors] ON;
    EXEC(N'INSERT INTO [Decors] ([DecorId], [CategoryId], [Description], [Image], [ImageUrl], [IsOnSale], [LinkUrl], [Name], [Price], [Stock])
    VALUES (1, 2, N''Cuddle up with a book a hot chocolate. Wrap yourself in this luxurious and incredibly soft blanket and you will never want to stop reading.'', N''/images/reading-blanket.jpg'', NULL, CAST(0 AS bit), N'''', N''Ultra soft plush reading blanket'', 34.99, 25),
    (2, 2, N''Everybody gets cold feet in the winter. Not anymore, with these incredibly warm and toast mid-calf socks. Your toes will thank you!'', N''/images/reading-socks.jpg'', NULL, CAST(0 AS bit), N'''', N''Plush Reading Socks'', 16.99, 45),
    (3, 2, N''Cozy shaw to wrap yourself in. Includes deep pockets. And sealed arm holes so it stays on. '', N''/images/wearable-blanket.jpg'', NULL, CAST(0 AS bit), N'''', N''Reading Shaw'', 24.99, 18),
    (4, 2, N''Light this comforting candle next time you sit down to read. Smells like rich warm leather, smoky woods, amber and vanilla. Close your eyes you might find yourself transport to Mr Poe''''s library. '', N''/images/edward-candle.jpg'', NULL, CAST(0 AS bit), N'''', N''Edgar Allen Poe''''s Library Candle'', 24.99, 35),
    (5, 2, N''Revitalize your home and reading experience with this candle warming lamp. Releases sent with a flame, soot, or polluntants. Combines wood, glass and gold finish. '', N''/images/candle-warming-lamp.jpg'', NULL, CAST(0 AS bit), N'''', N''Candle Warming Lamp'', 34.99, 23),
    (6, 2, N''This acacia wood book stand is perfect for keeping your reading glasses, phone and drinks within reach during your reading experience. Keep your page marked and your book safely stored.'', N''/images/book-caddy.jpg'', NULL, CAST(0 AS bit), N'''', N''Wooden Book Caddy'', 24.99, 60),
    (7, 2, N''Known for its calming and soothing properties. This heavy duty book will keep your books from failing and add great decor to all your shelves (or wherever else you like to store your books- HINT: Everywhere!).'', N''/images/bookend.jpg'', NULL, CAST(0 AS bit), N'''', N''Amethyst Crystal Book End'', 69.99, 20),
    (8, 2, N''Practice mindfullness with this sand garden. Make patterns in the sand by rolling or raking the included miniature rake or groove rock. '', N''/images/Home-Mindful_Garden.jpg'', NULL, CAST(0 AS bit), N'''', N''Mindful Texture Sand Garden'', 25.99, 13),
    (9, 2, N''Miniature globe paperweight. If you need a confidence boost, you can literally hold the world in your hands. Rotates 360 degrees. Beautiful for your office, desk, or bookshelf. '', N''/images/world-globe.jpg'', NULL, CAST(0 AS bit), N'''', N''Glass Globe Paperweight'', 29.99, 11),
    (10, 2, N''Clip on reading light, lightweight enough to not weight down your book and fit in your bag. Don''''t let the dark keep you from reading! Take AAA batteries'', N''/images/reading-light.jpg'', NULL, CAST(0 AS bit), N'''', N''Book Lover''''s Reading Light'', 14.99, 20),
    (11, 2, N''100% organic cotton Canvas bag with a reinforced base, a pocket for valuables, and a loop for keys. Comes with a Novel Nook exclusively currated print. Come prepared and carry your books everywhere.'', N''/images/tote-page.jpg'', NULL, CAST(0 AS bit), N'''', N''Novel Nook Exclusive Tote'', 34.99, 60),
    (12, 2, N''Introducing our own set of 3 candles specifically currated with our customers in mind. The smells include: Frosted Pine, Old Books, and Echanted Forest. Light one or all three.'', N''/images/candle-pack.jpg'', NULL, CAST(0 AS bit), N'''', N''Novel Nook Exclusive Candle Set'', 39.99, 22),
    (13, 2, N''Fill this ceramic vase with your favorite fresh flowers or store your utensils. Adorn your kitchen, or any space you wish with some bookish charm.8in tall and 6 in long. A great gift for the Pride and Predujice fan in your life.'', N''/images/PP-vase.jpg'', NULL, CAST(0 AS bit), N'''', N''Large Book Vase-Pride and Prejudice'', 24.99, 7),
    (14, 2, N''Beautiful black smooth calfskin leather jounral with snap closure and a gray ribbon bookmark. 150 ivory, worn edge  85 gsm pages'', N''/images/leather-journal.jpg'', NULL, CAST(0 AS bit), N'''', N''Black Leather Journal with Closure'', 29.99, 12),
    (15, 2, N''Make your reading experience more classy with these real leather and gold embossed corner book mars. 2 pack. A elegant addition to saving your spot in reading.'', N''/images/leather-bookmark.jpg'', NULL, CAST(0 AS bit), N'''', N''Leatherette Corner Bookmarks'', 9.99, 20)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'DecorId', N'CategoryId', N'Description', N'Image', N'ImageUrl', N'IsOnSale', N'LinkUrl', N'Name', N'Price', N'Stock') AND [object_id] = OBJECT_ID(N'[Decors]'))
        SET IDENTITY_INSERT [Decors] OFF;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Books_CategoryId] ON [Books] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Decors_CategoryId] ON [Decors] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_OrderItems_BookId] ON [OrderItems] ([BookId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_OrderItems_DecorId] ON [OrderItems] ([DecorId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_OrderItems_DecorId1] ON [OrderItems] ([DecorId1]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_OrderItems_OrderId] ON [OrderItems] ([OrderId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_OrderItems_ProductId] ON [OrderItems] ([ProductId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_OrderItems_SaleItemId] ON [OrderItems] ([SaleItemId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Orders_UserId] ON [Orders] ([UserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Product_CategoryId] ON [Product] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Review_ApplicationUserId] ON [Review] ([ApplicationUserId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Review_BookId] ON [Review] ([BookId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    CREATE INDEX [IX_Review_DecorId] ON [Review] ([DecorId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204230035_init'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251204230035_init', N'10.0.0');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204232407_addClearance'
)
BEGIN
    EXEC(N'UPDATE [Sales] SET [ImageUrl] = N''/Images/Book-Thumb2.jpg''
    WHERE [SaleId] = 6;
    SELECT @@ROWCOUNT');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204232407_addClearance'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251204232407_addClearance', N'10.0.0');
END;

COMMIT;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251210004246_AddValidation'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251210004246_AddValidation', N'10.0.0');
END;

COMMIT;
GO

