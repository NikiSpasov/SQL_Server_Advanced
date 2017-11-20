namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext() {}

        public FootballBettingContext(DbContextOptions options):base(options) {}

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity.HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.User)
                    .WithMany(u => u.Bets)
                    .HasForeignKey(b => b.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Color>(entity =>
            {
                entity.HasKey(c => c.ColorId);

            });

            builder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);

            });

            builder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.HasOne(g => g.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.AwayTeam)
                    .WithMany(ht => ht.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity.HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Position)
                    .WithMany(p => p.Players)
                    .HasForeignKey(p => p.PositionId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new {ps.PlayerId, ps.GameId});

                entity.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ps => ps.Game)
                    .WithMany(g => g.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId)
                    .OnDelete(DeleteBehavior.Restrict);


            });

            builder.Entity<Position> (entity =>
            {
                entity.HasKey(p => p.PositionId);

            });

            builder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity.HasOne(t => t.PrimaryKitColor)
                    .WithMany(col => col.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SecondaryKitColor)
                    .WithMany(col => col.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.HomeGames)
                    .WithOne(g => g.HomeTeam)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(t => t.AwayGames)
                    .WithOne(g => g.AwayTeam)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Town)
                    .WithMany(town => town.Teams)
                    .HasForeignKey(t => t.TownId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);
                entity.HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

            });

        }
    }
}
