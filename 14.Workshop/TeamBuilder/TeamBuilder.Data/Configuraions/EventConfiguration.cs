namespace TeamBuilder.Data.Configuraions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode();

            builder.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode()
                .IsRequired();
        }
    }
}
