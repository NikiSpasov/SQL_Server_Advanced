namespace TeamBuilder.Data.Configuraions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.InvitedUser)
                .WithMany(u => u.RecievedInvitations)
                .HasForeignKey(u => u.InvitedUserId);

            builder.HasOne(i => i.Team)
                .WithMany(t => t.Invitations)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
