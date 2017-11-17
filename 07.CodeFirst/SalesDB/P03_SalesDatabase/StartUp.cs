namespace P03_SalesDatabase
{
    using P03_SalesDatabase.Data;

    public class StartUp
    {
        static void Main()
        {
            using (var context = new SalesContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
