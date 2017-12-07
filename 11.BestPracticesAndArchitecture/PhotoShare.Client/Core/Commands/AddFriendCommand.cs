namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class AddFriendCommand : ICommand
    {
        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }
            throw new NotImplementedException();
        }
    }
}
