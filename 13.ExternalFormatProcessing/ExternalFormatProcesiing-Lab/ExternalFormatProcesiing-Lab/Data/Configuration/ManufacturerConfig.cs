using Microsoft.EntityFrameworkCore;

namespace ExternalFormatProcessingLab.Data.Configuration
{
    using ExternalFormatProcessingLab.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public  class ManufacturerConfig : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(50);
        }
    }
}