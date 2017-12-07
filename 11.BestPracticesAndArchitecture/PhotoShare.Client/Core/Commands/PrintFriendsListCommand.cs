namespace PhotoShare.Client.Core.Commands
{
    using System;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class PrintFriendsListCommand : ICommand
    {
        // PrintFriendsList <username>
        public string Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }
            // TODO prints all friends of user with given username.
            return "I'm PrintFriendsListCommand";
        }
    }
}
