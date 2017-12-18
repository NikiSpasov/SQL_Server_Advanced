using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
    using FastFood.Models;

    public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext() {}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

	    public DbSet<Category> Categories { get; set; }

	    public DbSet<Employee> Employees { get; set; }

	    public DbSet<Item> Items { get; set; }

	    public DbSet<Order> Orders { get; set; }

	    public DbSet<OrderItem> OrderItems { get; set; }

	    public DbSet<Position> Positions { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
		    builder.Entity<Item>()
                .HasAlternateKey(i => i.Name);

		    builder.Entity<Position>()
		        .HasAlternateKey(p => p.Name);

            builder.Entity<OrderItem>()
		        .HasKey(oi => new {oi.OrderId, oi.ItemId});

            //builder.Entity<Position>()
            //    .HasMany(p => p.Employees)
            //    .WithOne(e => e.Position)
            //    .HasForeignKey(e => e.PositionId);

            //builder.Entity<Category>()
            //    .HasMany(c => c.Items)
            //    .WithOne(i => i.Category)
            //    .HasForeignKey(i => i.CategoryId);

            //builder.Entity<Order>()
            //    .HasMany(o => o.OrderItems)
            //    .WithOne(c => c.Order)
            //    .HasForeignKey(i => i.OrderId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Item>()
            //    .HasMany(o => o.OrderItems)
            //    .WithOne(i => i.Item)
            //    .HasForeignKey(i => i.ItemId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
	}
}