namespace P02_DatabaseFirst.Data
{
    using FirstDemo.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data.Models.Configuration;

    public class SoftUniDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeProject> EmployeesProjects { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Town> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfiguration());

            modelBuilder.ApplyConfiguration(new DepartmentsConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new EmployeesProjectsConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectCofiguration());

            modelBuilder.ApplyConfiguration(new TownConfiguration());
        }
    }
}
