namespace Employees.App.Core.Commands

{
    using System;
    using Contracts;
    using ICommand = Employees.App.Core.Commands.Contracts.ICommand;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] args)
        {
            Console.WriteLine("GoodBye!");
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
