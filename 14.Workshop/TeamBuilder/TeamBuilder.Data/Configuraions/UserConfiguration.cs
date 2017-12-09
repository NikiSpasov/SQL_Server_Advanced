namespace TeamBuilder.Data.Configuraions
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasAlternateKey(b => b.Username);

            builder.Property(u => u.Username)
                .IsRequired();

            builder.Property(u => u.Firstname)
                .HasMaxLength(25);

            builder.Property(u => u.Lastname)
                .HasMaxLength(25);

            builder.Property(u => u.Password)
                .IsRequired();

            builder.HasMany(u => u.RecievedInvitations)
                .WithOne(i => i.InvitedUser)
                .HasForeignKey(i => i.InvitedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedUserTeams)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
