﻿namespace P02_DatabaseFirst.Data.Models.Configuration
{
    using FirstDemo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DepartmentsConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {    
                builder.HasKey(e => e.DepartmentId);

                builder.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                builder.Property(e => e.ManagerId).HasColumnName("ManagerID");

                builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                builder.HasOne(d => d.Manager)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Departments_Employees");
        }
    }
}
