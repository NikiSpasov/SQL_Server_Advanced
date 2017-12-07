namespace Forum.Services
{
    using Forum.Models;
    using Forum.Services.Contracts;

    public class UserSessionService : IUserSessionService
    {
        private readonly IUserService userService;

        public UserSessionService(IUserService userService)
        {
            this.userService = userService;
        }

        public User User { get; set; }

        public User Login(string username, string password)
        {
            this.User = this.userService.ByUsernameAndPassword<User>(username, password);
            return this.User;
        }

        public void Logout() => this.User = null;

        public bool IsLoggedIn() => this.User != null;
    }
}
