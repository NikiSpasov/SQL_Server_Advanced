namespace Forum.App.Commands
{
    using Forum.App.Commands.Contracts;
    public class LogoutCommand : ICommand
    {
        public string Execute(params string[] arguments)
        {
            if (Session.User == null)
            {
                return "You are not logged in!";
            }

            Session.User = null;

            return "Logged out sucessfully";
        }
    }
}
