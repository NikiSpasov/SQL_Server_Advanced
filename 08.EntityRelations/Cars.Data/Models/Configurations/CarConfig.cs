namespace Cars.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            //ONE - TO -ONE
            builder
                .HasOne(c => c.LicencePlate)
                .WithOne(lp => lp.Car)
                .HasForeignKey<LicencePlate>(lp => lp.CarId);

            //Many -To - One - WARNING With the FOREIGN KEY: (2nd == 3th)
            builder
                .HasMany(c => c.CarDealerships)
                .WithOne(cd => cd.Car)
                .HasForeignKey(cd => cd.CarId);
        }
    }
}
