namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(params string[] data)
        {
            return "I'm the exit command";
        }
    }
}
