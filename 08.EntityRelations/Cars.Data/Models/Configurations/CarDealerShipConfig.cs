namespace Cars.Data.Models.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CarDealershipConfig : IEntityTypeConfiguration<CarDealership>
    {
        public void Configure(EntityTypeBuilder<CarDealership> builder)
        {
            builder.HasKey(cd => new { cd.CarId, cd.DealershipId });

            builder.ToTable("CarsDealerships");
            //One-To-Many - WARNING with the FOREIGN KEY (1st == 3th):
            builder.HasOne(cd => cd.Car)
                .WithMany(c => c.CarDealerships)
                .HasForeignKey(c => c.CarId);
            
            builder.HasOne(d => d.Dealership)
                .WithMany(d => d.CarDealerships)
                .HasForeignKey(cd => cd.DealershipId);
        }
    }
}
