namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    using Forum.Models;
    using Forum.Services.Contracts;

    public class RegisterCommand : ICommand
    {
        private readonly IUserService userService;

        public RegisterCommand(IUserService userService)
        {
            this.userService = userService;
        }

        string ICommand.Execute(params string[] arguments)
        {
            var username = arguments[0];
            var password = arguments[1];

            var existingUser = this.userService.ByUsername<User>(username);

            if (existingUser != null)
            {
                return "There is already an existing user with this username!";
            }

            this.userService.Create<User>(username, password);

            return "User created successfully";
        }
    }
}