using System;
using System.Collections.Generic;
using System.Text;

namespace P02_DatabaseFirst.Data.Models.Configuration
{
    using FirstDemo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
                builder.HasKey(e => e.AddressId);

                builder.Property(e => e.AddressId).HasColumnName("AddressID");

                builder.Property(e => e.AddressText)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                builder.Property(e => e.TownId).HasColumnName("TownID");

                builder.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .HasConstraintName("FK_Addresses_Towns");
        }
    }
}
