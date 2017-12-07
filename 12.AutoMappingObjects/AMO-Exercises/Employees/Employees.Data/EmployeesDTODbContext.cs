namespace Employees.Data
{
    using Employees.Data.Configurations;
    using Employees.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeesDtoDbContext : DbContext
    {
        public EmployeesDtoDbContext(){ }

        public EmployeesDtoDbContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
