namespace PhotoShare.Client.Core
{
    using System;
    using PhotoShare.Data;

    public class Engine
    {
        private readonly CommandDispatcher commandDispatcher;

        public Engine()
        {
            this.commandDispatcher = new CommandDispatcher();
        }

        public void Run()
        {
            //ResetDatabase();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();

                    string[] data = input.Split(new []{' '}, 
                             StringSplitOptions.RemoveEmptyEntries);

                    if (data.Length > 0 && data[0] == "Exit")
                    {
                        Console.WriteLine("Bye-bye!");
                        Environment.Exit(0);
                    }

                    string result = this.commandDispatcher.DispatchCommand(data);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ResetDatabase()
        {
            using (var db = new PhotoShareContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }
}
