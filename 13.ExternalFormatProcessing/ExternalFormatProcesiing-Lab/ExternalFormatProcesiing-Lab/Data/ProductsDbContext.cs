namespace ExternalFormatProcesiingLab.Data
{
    using ExternalFormatProcessingLab.Data.Configuration;
    using ExternalFormatProcessingLab.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext() {}

        public ProductsDbContext(DbContextOptions options) : base(options) {}

        DbSet<Product> Products { get; set; }

        DbSet<Warehouse> Warehouses { get; set; }

        DbSet<Manufacturer> Manafacturers { get; set; }

        DbSet<ProductsWarehouse> ProductsWarehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ManufacturerConfig());
            builder.ApplyConfiguration(new ProductConfig());
            builder.ApplyConfiguration(new WarehouseConfig());
            builder.ApplyConfiguration(new ProductsWarehouseConfig());
        }
    }
}
