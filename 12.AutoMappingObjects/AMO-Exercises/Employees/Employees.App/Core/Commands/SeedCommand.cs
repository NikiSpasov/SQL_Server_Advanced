namespace Employees.App.Core.Commands
{
    using Employees.App.Core.Commands.Contracts;
    using Employees.Services;
    using Employees.Services.Contracts;

    public class SeedCommand : ICommand
    {
        private readonly IDatabaseInitializerService databaseInitializer;

        public SeedCommand(IDatabaseInitializerService databaseInitializer)
        {
            this.databaseInitializer = databaseInitializer;
        }

        public string Execute(params string[] args)
        {
            this.databaseInitializer.Seed();

            return "Data seeded!";
        }
    }
}
