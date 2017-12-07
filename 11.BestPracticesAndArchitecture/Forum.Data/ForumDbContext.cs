namespace Forum.Data
{
    using Forum.Models;
    using Microsoft.EntityFrameworkCore;

    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
        {
            
        }

        public ForumDbContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
            });

            builder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
            });

            builder.Entity<Reply>(entity =>
            {
                entity.HasKey(r => r.Id);

                entity.HasOne(e => e.Post)
                    .WithMany(e => e.Replies)
                    .HasForeignKey(r => r.PostId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
            });
        }
    }
}
