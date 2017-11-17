namespace HospitalStartUp
{
    using HospitalDatabaseInitializer;
    using P01_HospitalDatabase.Data;

    public class StartUp
    {
        public static void Main()
        {

            //DatabaseInitializer.ResetDatabase();
            using (var db = new HospitalContext())
            {
                DatabaseInitializer.SeedPatients(db, 100);
            }
        }
    }
}
