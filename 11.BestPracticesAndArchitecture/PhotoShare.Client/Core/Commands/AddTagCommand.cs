namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using Data;
    using PhotoShare.Client.Core.Commands.Contracts;
    using Utilities;

    public class AddTagCommand : ICommand
    {
        // AddTag <tag>
        public string Execute(string[] data)
        {
            if (data.Length != 1)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }

            string tag = data[0].ValidateOrTransform();

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if (context.Tags.Any(t => t.Name.Equals(tag)))
                {
                    throw new ArgumentException($"Tag {tag} exist!");
                }

                context.Tags.Add(new Tag
                {
                    Name = tag
                });

                context.SaveChanges();
            }

            return tag + " was added successfully to database!";
        }
    }
}
