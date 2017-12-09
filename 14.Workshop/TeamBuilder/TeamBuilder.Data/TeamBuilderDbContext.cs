namespace TeamBuilder.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeamBuilder.Data.Configuraions;
    using TeamBuilder.Models;

    public class TeamBuilderDbContext : DbContext
    {
        public TeamBuilderDbContext() { }

        public TeamBuilderDbContext(DbContextOptions options) 
            :base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Invitation> Invitations { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<EventTeams> EventTeams { get; set; }

        public DbSet<UserTeams> UserTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new TeamConfiguration());

            builder.ApplyConfiguration(new InvitationConfiguration());

            builder.ApplyConfiguration(new UserTeamConfiguration());

            builder.ApplyConfiguration(new EventTeamConfiguration());

            builder.ApplyConfiguration(new EventConfiguration());
        }
    }
}
