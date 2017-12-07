namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class AddTagToCommand : ICommand
    {
        // AddTagTo <albumName> <tag>
        public string Execute(params string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }
            throw new NotImplementedException();
        }
    }
}
