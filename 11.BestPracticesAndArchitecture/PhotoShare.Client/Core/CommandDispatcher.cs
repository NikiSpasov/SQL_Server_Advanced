namespace PhotoShare.Client.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            try
            {
                if (commandParameters.Length == 0)
                {
                    throw new InvalidOperationException();
                }

                Assembly currentAssembly = Assembly.GetExecutingAssembly();

                var commandTypes = currentAssembly
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                    .ToArray();
                //.FirstOrDefault(t => t.Name == $"{commandParameters[0]}Command");

                var commandType = commandTypes.SingleOrDefault(t => t.Name == $"{commandParameters[0]}Command");

                if (commandType != null)
                {
                    var constructor = commandType.GetConstructors().FirstOrDefault();
                    var parametersForExecution = commandParameters.Skip(1).ToArray();
                    var command = (ICommand)constructor.Invoke(null);
                    return command.Execute(parametersForExecution);
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            catch (InvalidOperationException e)
            {
                if (commandParameters.Length != 0)
                {
                    return $"Command {commandParameters[0]} not valid";
                }
                return "";
            }
        }
    }
}

