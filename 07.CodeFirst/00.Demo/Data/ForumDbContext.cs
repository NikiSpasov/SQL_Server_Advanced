using Forum.Data.Models;
using Microsoft.EntityFrameworkCore;



public class ForumDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("");
        if (!optionsBuilder.IsConfigured)
        {
            
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}

