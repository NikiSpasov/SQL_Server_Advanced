namespace Employees.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Employees.App.Core.Commands.Contracts;

    public class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                .ToArray();

            var commandType = commandTypes
                .SingleOrDefault(t => t.Name.ToLower() == $"{commandName.ToLower()}command");
            //here is .ToLower - to write commands how we want

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var constructor = commandType.GetConstructors().First();

            var constructorParameteres = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .ToArray();

            var services = constructorParameteres
                .Select(serviceProvider.GetService)
                .ToArray();

            var command = (ICommand) constructor.Invoke(services);

            return command;
        }
    }
}
