namespace TeamBuilder.App.Core
{
    using System;
    using TeamBuilder.Data;

    public class Engine
    {
        public void Run()
        {
            using (var context = new TeamBuilderDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.GetBaseException().Message);
                }
            }
        }
    }
}
