namespace Forum
{
    using System;
    using System.Linq;
    using System.Text;
    using Forum.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class StratUp
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var context = new ForumDbContext();

            //ResetDatabase(context);


            //var tags = new[]
            //{
            //    new Tag {Name = "C#"},
            //    new Tag {Name = "Programming"},
            //    new Tag {Name = "Praise"},
            //    new Tag {Name = "Maicrosoft"},
            //};

            //var postTags = new[]
            //{
            //    new PostTag {PostId = 1, Tag = tags[0]},
            //    new PostTag {PostId = 1, Tag = tags[1]},
            //    new PostTag {PostId = 1, Tag = tags[2]},
            //    new PostTag {PostId = 1, Tag = tags[3]},

            //};

            //context.Tags.AddRange(tags);
            //context.PostTags.AddRange(postTags);

            //context.SaveChanges();

            // ResetDatabase(context);

            //var categories = context.Categories
            //    .Include(c => c.Posts)
            //    .ThenInclude(c => c.Author)
            //    .Include(c => c.Posts)
            //    .ThenInclude(p => p.Replies)
            //    .ThenInclude(r => r.Author)
            //    .ToArray();

            var categories = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    Posts = c.Posts.Select(p => new
                    {
                        Title = p.Title,
                        Content = p.Content,
                        AuthorUsername = p.Author.Username,
                        Replies = p.Replies.Select(r => new
                        {
                            Content = r.Content,
                            AuthorUsername = r.Author.Username
                           
                        }),
                        Tags = p.PostTags.Select(t => t.Tag.Name)
                        .ToArray()
                    })
                    .ToArray()
                })
                .ToArray();


            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Name} ({category.Posts.Count()})");

                foreach (var post in category.Posts)
                {
                    Console.WriteLine($"--{post.Title}: {post.AuthorUsername}");
                    Console.WriteLine($"--by {post.AuthorUsername}");

                    Console.WriteLine("Tags: " + string.Join(", ", post.Tags));

                    foreach (var reply in post.Replies)
                    {
                        Console.WriteLine($"---{reply.Content} from {reply.AuthorUsername}");
                    }
                }
            }

        }

        private static void ResetDatabase(ForumDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(ForumDbContext context)
        {
            var users = new[]
            {
                new User("Gosho", "123"),
                new User("Pesho", "123"),
                new User("Ivan", "123"),
                new User("Merry", "123"),

            };

            context.Users.AddRange(users);

            var categories = new[]
            {
                new Category("C#"),
                new Category("Support"),
                new Category("Python"),
                new Category("EF KOP")
            };

            var post = new[]
            {
                new Post("C# Rulz", "Верно", categories[0], users[0]),
                new Post("Python Rulz", "пак верно", categories[2], users[1]),
                new Post("My computer is shiT", "Верно", categories[1], users[2]),
            };

            context.Posts.AddRange(post);

            var replies = new[]
            {
                new Reply("Turn it on", post[2], users[0]),
                new Reply("Yep", post[0], users[3]),

            };

            context.AddRange(replies);

            context.SaveChanges();
        }
    }
}
