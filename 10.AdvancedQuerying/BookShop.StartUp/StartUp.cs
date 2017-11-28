namespace BookShop.StartUp
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Text.RegularExpressions;
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main()
        {


            string input = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);
                string result = GetBooksByAuthor(db, input);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int enumValue = -1;

            switch (command.ToLower())
            {
                case "minor":
                    enumValue = 0;
                    break;
                case "teen":
                    enumValue = 1;
                    break;
                case "adult":
                    enumValue = 2;
                    break;
            }

            string[] titles = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)enumValue)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context
                .Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(a => $"{a.Title} - ${a.Price}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {

            string[] books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(new[] { "\t", " ", Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            var titles = context.Books
                  .Where(b => b.BookCategories.Any
                  (c => categories.Contains(c.Category.Name.ToLower())))
                  .Select(b => b.Title)
                  .OrderBy(t => t)
                  .ToArray();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime checkDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            string[] books = context.Books
                .Where(b => b.ReleaseDate < checkDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:f2}")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            string pattern = $"^{input.ToLower()}.*$";

            string[] books = context.Books
                .Where(b => Regex.Match(b.Author.LastName.ToLower(), pattern).Success)
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.Copies)
                .ToArray();

            string[] authorString = authors.Select(a => $"{a.Name} - {a.Copies}").ToArray();

            return string.Join(Environment.NewLine, authorString);

            //var builder = new StringBuilder();

            //foreach (var a in authors)
            //{
            //    builder.AppendLine($"{a.Name} - {a.Copies}");
            //}

            //return builder.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories.OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                }).ToArray();

            var builder = new StringBuilder();

            foreach (var c in categories)
            {
                builder.AppendLine($"---{c.Name}");
                foreach (var b in c.Books)
                {
                    string year = null;

                    if (b.ReleaseDate == null)
                    {
                        year = "N/A";
                    }
                    else
                    {
                        year = b.ReleaseDate.Value.Year.ToString();
                    }
                    builder.Append($"{b.Title} ({year})");
                }
            }
            return builder.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var b in books)
            {
                b.Price += 5m;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200);

            int result = books.Count();

            context.Books.RemoveRange(books);

            Console.WriteLine(books.Count());

            context.SaveChanges();

            return result;
        }

    }
}
