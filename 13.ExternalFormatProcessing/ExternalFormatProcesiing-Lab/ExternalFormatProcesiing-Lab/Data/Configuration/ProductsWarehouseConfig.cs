using Microsoft.EntityFrameworkCore;

namespace ExternalFormatProcessingLab.Data.Configuration
{
    using ExternalFormatProcessingLab.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductsWarehouseConfig : IEntityTypeConfiguration<ProductsWarehouse>
    {
        public void Configure(EntityTypeBuilder<ProductsWarehouse> builder)
        {
            builder.HasKey(pw => new {pw.ProductId, pw.WarehouseId});

            builder.HasOne(pw => pw.Warehouse)
                .WithMany(w => w.ProductsWarehouses)
                .HasForeignKey(p => p.WarehouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pw => pw.Product)
                .WithMany(p => p.ProductsWarehouses)
                .HasForeignKey(pr => pr.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}