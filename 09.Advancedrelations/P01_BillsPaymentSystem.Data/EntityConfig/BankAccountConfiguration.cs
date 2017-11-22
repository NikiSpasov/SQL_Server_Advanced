namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentSystem.Data.Models;

    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(ba => ba.BankAccountId);
            builder.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.SWIFTCode)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}
