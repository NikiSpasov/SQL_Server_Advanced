namespace Forum.Services
{
    using Forum.Data;
    using Forum.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializerService : IDatabaseInitializerService
    {
        private readonly ForumDbContext context;

        public DatabaseInitializerService(ForumDbContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }

        public void DeleteDatabase()
        {
            this.context.Database.EnsureDeleted();
        }
    }
}