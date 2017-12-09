namespace TeamBuilder.Data.Configuraions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class TeamConfiguration  :IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasAlternateKey(t => t.Name);

            builder.Property(t => t.Name)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(32);

            builder.Property(t => t.Acronym)
                .HasColumnType("char(3)")               //HasMaxLength(3)
                .IsRequired();

        }
    }
}
