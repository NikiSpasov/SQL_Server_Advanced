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
                .IsRequired()
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.SwitCode)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Ignore(e => e.PaymentMethodId);
        }
    }
}
