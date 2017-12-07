namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Data;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class DeleteUserCommand : ICommand
    {
        public string Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }

            string username = data[0];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);
                if (user == null)
                {
                    throw new InvalidOperationException($"User with {username} was not found!");
                }

                user.IsDeleted = true;

                context.SaveChanges();

                return $"User {username} was deleted from the database!";
            }
        }
    }
}
