using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.Data.Configurations
{
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(e => e.Address)
                .HasMaxLength(250);

           // builder.Property(e => e.Birthday)
            //    .HasColumnType(typeName: "YEAR");
        }
    }
}

