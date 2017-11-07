using System;
using System.Data.SqlClient;


public class StartUp
{
    public static void Main()
    {
        string connectionString = "Server=.;Database=MinionsDB;Integrated security = True";
        var connection = new SqlConnection(connectionString);

        int villianId = int.Parse(Console.ReadLine());

        connection.Open();

        using (connection)
        {
            try
            {
                string nameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
                var nameCommand = new SqlCommand(nameQuery, connection);
                nameCommand.Parameters.AddWithValue("@viliainId", villianId);
                var reader = nameCommand.ExecuteReader();
                reader.Read();
                if (!reader.Read())
                {
                    //reader.Close();
                    throw new ArgumentException("No such villain was found.");
                }
                string villianName = Convert.ToString(reader[0]);
                //reader.Close();

                var mvQuery = "DELETE FROM MinionsVillains WHERE VillianId = @villianId";
                var mvCommand = new SqlCommand(mvQuery, connection);
                mvCommand.Parameters.AddWithValue("@villianId", villianId);
                int minionsRealeased = mvCommand.ExecuteNonQuery();


                string villianQuerry = "DELETE FROM Villains WHERE Id = @villianId";
                var villianCommand = new SqlCommand(villianQuerry, connection);
                villianCommand.Parameters.AddWithValue("@villianId", villianId);
                villianCommand.ExecuteNonQuery();

                Console.WriteLine($"{villianName} was deleted.");

                Console.WriteLine($"{minionsRealeased} minions were released");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
    static void ExecuteCommand(string command, SqlConnection connection)
    {
        var sql = new SqlCommand(command, connection);
        sql.ExecuteNonQuery();
    }
}
