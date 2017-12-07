using Microsoft.EntityFrameworkCore;

namespace ExternalFormatProcessingLab.Data.Configuration
{
    using ExternalFormatProcessingLab.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class WarehouseConfig : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.Id);

            builder.Property(w => w.Location)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
        }
    }
}