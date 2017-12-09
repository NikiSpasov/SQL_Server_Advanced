namespace TeamBuilder.Data.Configuraions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class EventTeamConfiguration : IEntityTypeConfiguration<EventTeams>
    {
        public void Configure(EntityTypeBuilder<EventTeams> builder)
        {
            builder.ToTable("EventTeams");

            builder.HasKey(et => new {et.EventId, et.TeamId});

            builder.HasOne(et => et.Team)
                .WithMany(t => t.EventTeams)
                .HasForeignKey(et => et.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(et => et.Event)
                .WithMany(e => e.EventTeams)
                .HasForeignKey(et => et.EventId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
