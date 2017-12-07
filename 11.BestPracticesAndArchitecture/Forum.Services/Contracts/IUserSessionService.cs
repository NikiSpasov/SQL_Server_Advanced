namespace Forum.Services.Contracts
{
    using Forum.Models;

    public interface IUserSessionService
    {
        User Login(string username, string password);

        void Logout();

        User User { get; }

        bool IsLoggedIn();
    }
}
