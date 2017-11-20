namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;

    public class StartUp
    {
        static void Main()
        {
            using (var db = new FootballBettingContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}