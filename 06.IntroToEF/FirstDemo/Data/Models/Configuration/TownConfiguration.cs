namespace P02_DatabaseFirst.Data.Models.Configuration
{
    using FirstDemo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {

            builder.HasKey(e => e.TownId);

            builder.Property(e => e.TownId).HasColumnName("TownID");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
