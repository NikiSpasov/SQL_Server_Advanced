namespace P01_BillsPaymentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentSystem.Data.EntityConfig;
    using P01_StudentSystem;

    public class BillsPaymentsSystemContext : DbContext
    {
        public BillsPaymentsSystemContext() { }

        public BillsPaymentsSystemContext(DbContextOptions options) :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new BankAccountConfiguration());

            builder.ApplyConfiguration(new CreditCardConfiguration());

            builder.ApplyConfiguration(new PaymentMethodConfiguration());
        }
    }
}
