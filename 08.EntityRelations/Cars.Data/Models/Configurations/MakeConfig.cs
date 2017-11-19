namespace Cars.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MakeConfig : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            builder.HasMany(m => m.Cars)
                .WithOne(c => c.Make)
                .HasForeignKey(c => c.MakeId);
        }
    }
}
