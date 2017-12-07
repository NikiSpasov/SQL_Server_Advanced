namespace ExternalFormatProcessingLab.Data
{
    using ExternalFormatProcesiingLab.Data;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseInitializer
    {
        private readonly ProductsDbContext context;

        public DatabaseInitializer(ProductsDbContext context)
        {
            this.context = context;
        }

        public string ResetDatabase()
        {
            //this.context.Database.EnsureDeleted();
            //this.context.Database.EnsureCreated();
            //this.context.Database.Migrate();
            return "DB created!";
        }
    }
}
