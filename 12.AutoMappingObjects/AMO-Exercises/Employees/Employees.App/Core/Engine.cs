namespace Employees.App.Core
{
    using System;
    using System.Linq;
    using Employees.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;

    public class Engine
    {
        private readonly IServiceProvider serviceProvider; //needed for dependency injection;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var databaseInitService = this.serviceProvider.GetService<IDatabaseInitializerService>(); //====> here is Dependency injection - not with new class and instance / object
                                                                                                      //from it, but with generic method GetServices from IServiceProvider interface from Microsoft.Extensions.DependencyInjection
            databaseInitService.InitializeDatabase();

            while (true)
            {
                Console.Write("Enter Command: ");

                var input = Console.ReadLine()
                    .Trim()
                    .Split(' ');

                var commandName = input[0];

                var commandArgs = input.Skip(1).ToArray();

                try
                {
                    var command = CommandParser.ParseCommand(this.serviceProvider, commandName);

                    var result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }   
            }                
        }
    }
}
