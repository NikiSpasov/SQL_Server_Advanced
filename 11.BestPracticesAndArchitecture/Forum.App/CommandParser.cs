namespace Forum.App
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Forum.App.Commands.Contracts;

    public class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                 .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                 .ToArray();

            var commandType = commandTypes
                .SingleOrDefault(t => t.Name == $"{commandName}Command");

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

            var command = (ICommand)constructor.Invoke(services);

            return command;
        }
    }
}
