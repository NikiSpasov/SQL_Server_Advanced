namespace TeamBuilder.Data.Configuraions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class UserTeamConfiguration : IEntityTypeConfiguration<UserTeams>
    {
        public void Configure(EntityTypeBuilder<UserTeams> builder)
        {
            builder.HasKey(ut => new {ut.TeamId, ut.UserId});

            builder.HasOne(ut => ut.User)
                .WithMany(ut => ut.CreatedUserTeams)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ut => ut.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(ut => ut.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
