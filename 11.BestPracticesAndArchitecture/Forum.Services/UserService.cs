namespace Forum.Services
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Forum.Data;
    using Forum.Models;
    using Forum.Services.Contracts;

    public class UserService : IUserService
    {
        private readonly ForumDbContext context;

        public UserService(ForumDbContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id)
        {
            return this.context
                .Users
                .Where(u => u.Id == id)
                .ProjectTo<TModel>()
                .SingleOrDefault();
        }

        public TModel ByUsername<TModel>(string username)
        {
            return this.context
                .Users
                .Where(u => u.Username == username)
                .ProjectTo<TModel>()
                .SingleOrDefault();
        }

        public TModel ByUsernameAndPassword<TModel> (string username, string password)
        {
            return this.context
                .Users
                .Where(u => u.Username == username && u.Password == password)
                .ProjectTo<TModel>()
                .SingleOrDefault();
        }

        public TModel Create<TModel>(string username, string password)
        {
            var user = new User(username, password);

            this.context.Users.Add(user);

            this.context.SaveChanges();

            var userDto = Mapper.Map<TModel>(user);

            return userDto;
        }

        public void Delete(int id)
        {
            var user = this.context.Users.Find(id);
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}
