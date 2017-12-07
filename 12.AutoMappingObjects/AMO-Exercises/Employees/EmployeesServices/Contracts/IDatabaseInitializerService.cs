namespace Employees.Services.Contracts
{
    public interface IDatabaseInitializerService
    {
        void DeleteDatabase();

        void InitializeDatabase();

        void Seed();
    }
}
