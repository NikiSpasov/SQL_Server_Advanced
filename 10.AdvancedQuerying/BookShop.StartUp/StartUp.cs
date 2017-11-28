namespace BookShop.StartUp
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using BookShop.Data;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
           int input = int.Parse(Console.ReadLine());

            using (var db = new BookShopContext())
            {
                string result = GetBooksNotRealeasedIn(db, input);
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
                .Where(b => b.AgeRestriction == (AgeRestriction) enumValue)
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


    }
}
