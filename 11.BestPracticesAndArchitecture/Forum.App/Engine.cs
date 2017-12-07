namespace Forum.App
{
    using System;
    using System.Linq;
    using Forum.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var databaseInitializerService = this.serviceProvider.GetService<IDatabaseInitializerService>();

            //databaseInitializerService.DeleteDatabase();

            databaseInitializerService.InitializeDatabase();

            while (true)
            {
                Console.Write("Enter command: ");
                var input = Console.ReadLine();

                var commandTokens = input.Split(' ');

                var commandName = commandTokens.First();

                var commandArgs = commandTokens.Skip(1).ToArray();

                try
                {
                    var command = CommandParser.ParseCommand(this.serviceProvider, commandName);

                    var result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }    
            }
        }
    }
}
