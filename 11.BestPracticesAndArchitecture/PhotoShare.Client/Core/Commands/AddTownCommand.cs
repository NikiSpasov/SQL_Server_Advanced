namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using Models;
    using Data;
    using PhotoShare.Client.Core.Commands.Contracts;

    public class AddTownCommand : ICommand
    {
        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            if (data.Length != 2)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }

            string townName = data[0];
            string country = data[1];

            using (PhotoShareContext context = new PhotoShareContext())
            {
                if (context.Towns.Any(t => t.Name == townName))
                {
                    throw new ArgumentException($"Town {townName} was already added!");
                }

                Town town = new Town
                {
                    Name = townName,
                    Country = country
                };

                context.Towns.Add(town);
                context.SaveChanges();

                return town.Name + " was added to database!";
            }
        }
    }
}
