namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;
    using PhotoShare.Client.Core.Commands.Contracts;
    using PhotoShare.Data;
    using PhotoShare.Models;

    public class ModifyUserCommand : ICommand
    {
        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            if (data.Length != 3)
            {
                throw new InvalidOperationException($"Command {this.GetType().Name} not valid!");
            }

            string userName = data[0];
            string property = data[1];
            string newValue = data[2];

            using (var context = new PhotoShareContext())
            {
                var user = context.Users.First(u => u.Username == userName);
                if (user == null)
                {
                    throw new ArgumentException($"User {userName} not found!");
                }

                var propertyCollection = typeof(User).GetProperties();

                if (propertyCollection.All(pc => pc.Name != property))
                {
                    throw new ArgumentException($"Property {property} not supported!");
                }


                try
                {
                    switch (property)
                    {
                        case "Password":
                            if (!newValue.Any(c => char.IsLower(c) &&
                                                   newValue.Any(ch => char.IsDigit(ch))))
                            {
                                throw new ArgumentException($"Invalid password");
                            }
                            user.Password = newValue;

                            break;


                        case "BornTown":
                            if (!context.Towns.Any(t => t.Name == newValue))
                            {
                                throw new ArgumentException($"Town {newValue} not found!");
                            }

                            var bornTown = context.Towns.First(t => t.Name == newValue);

                            user.BornTown = bornTown;

                            break;


                        case "CurrentTown":
                            if (!context.Towns.Any(t => t.Name == newValue))
                            {
                                throw new ArgumentException($"Town {newValue} not found!");
                            }

                            var currentTown = context.Towns.First(t => t.Name == newValue);
                            user.CurrentTown = currentTown;
                            break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                context.SaveChanges();

                return $"User {userName} {property} is {newValue}.";
            }
        }
    }
}
