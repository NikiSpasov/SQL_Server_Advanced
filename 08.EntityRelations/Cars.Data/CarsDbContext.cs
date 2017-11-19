namespace Cars.Data
{
    using Cars.Data.Models;
    using Cars.Data.Models.Configurations;
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase;

    public class CarsDbContext : DbContext
    {
        public CarsDbContext() {}
        public CarsDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<LicencePlate> LicencePlates { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Dealership> Dealerships { get; set; }
        public DbSet<CarDealership> CarDealerships { get; set; }
        // ??? public DbSet<CarDealership> CarDealerships { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfig());

            //below went to a class:

            //builder.Entity<Car>(entity =>
            //{
            //    entity.HasKey(c => c.Id);
            //    //ONE - TO -ONE
            //    entity
            //        .HasOne(c => c.LicencePlate)
            //        .WithOne(lp => lp.Car)
            //        .HasForeignKey<LicencePlate>(lp => lp.CarId);

            //    //Many -To - One - WARNING With the FOREIGN KEY: (2nd == 3th)
            //    entity
            //        .HasMany(c => c.CarDealerships)
            //        .WithOne(cd => cd.Car)
            //        .HasForeignKey(cd => cd.CarId);

            //} );

            builder.ApplyConfiguration(new EngineConfig());
            //builder.Entity<Engine>(entity =>
            //{
                //entity
                //    .HasMany(e => e.Cars)
                //    .WithOne(c => c.Engine)
                //    .HasForeignKey(c => c.EngineId);

            //});
            builder.ApplyConfiguration(new MakeConfig());
            //gone to a special class MakeConfig
            //builder.Entity<Make>(entity =>
            //{
            //    entity.HasMany(m => m.Cars)
            //        .WithOne(c => c.Make)
            //        .HasForeignKey(c => c.MakeId);

            //});

            builder.Entity<Dealership>(entity =>
            {


            });


            //MANY - TO - MANY

            //MANY - tp - MANY works like that:
            // - in two classes put collection of 
            //third class, wich is glue of those two classes.
            //in .NET FrameWork there is hasmany.WithMany, but
            //int .NET Core this is NOT Working.
            //in EF Core, in Fluent API you have to define
            //a composite key, then two-way direction (see below):

            builder.ApplyConfiguration(new CarDealershipConfig());


            //BELOW code WENT TO A CarDealershipConfig class!
            //builder.Entity<CarDealership>(entity =>
            //{
            //    entity.HasKey(cd => new {cd.CarId, cd.DealershipId});

            //    //One-To-Many - WARNING with the FOREIGN KEY (1st == 3th):
            //    entity.HasOne(cd => cd.Car)
            //        .WithMany(c => c.CarDealerships)
            //        .HasForeignKey(c => c.CarId);

            //    entity.HasOne(d => d.Dealership)
            //        .WithMany(d => d.CarDealerships)
            //        .HasForeignKey(cd => cd.DealershipId);

            //});

        }
    }
}
