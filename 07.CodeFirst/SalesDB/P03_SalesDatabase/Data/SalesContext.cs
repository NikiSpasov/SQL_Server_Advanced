namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext() { }
        public SalesContext(DbContextOptions options)
            :base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(100);

                entity.Property(c => c.Email)
                    .IsUnicode(false)
                    .HasMaxLength(80);
            });

            model.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode()
                    .HasMaxLength(50);

                entity.Property(x => x.Price)
                    .IsRequired();

                entity.Property(p => p.Description)
                    .HasMaxLength(250)
                    .IsUnicode()
                    .HasDefaultValue("No Description");
            });

            model.Entity<Sale>(entity =>
            {
                entity.HasKey(s => s.SaleId);

               entity.Property(e => e.Date)
                    .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(p => p.ProductId);

                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Sales)
                    .HasForeignKey(c => c.CustomerId);
                 
                entity.HasOne(s => s.Store)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(p => p.StoreId);
            });

            model.Entity<Store>(entity =>
            {
                entity.HasKey(s => s.StoreId);

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode();
            });

        }
    }
}
