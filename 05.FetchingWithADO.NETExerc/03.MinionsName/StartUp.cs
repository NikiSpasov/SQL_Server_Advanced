using System;
using System.Data.SqlClient;


public class StartUp
{
    public static void Main()
    {
        string connectionString = "Server=NikiThinkPad\\SQLEXPRESS;Database=MinionsDB;Integrated security = True";
        var connection = new SqlConnection(connectionString);

        int villianId = int.Parse(Console.ReadLine());

        connection.Open();

        using (connection)
        {
            string villianQuery = "SELECT Name FROM Villains WHERE Id = @villianId";
            var villiandCommand = new SqlCommand(villianQuery, connection);

            villiandCommand.Parameters.AddWithValue("@villianId", villianId);

            SqlDataReader reader = villiandCommand.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"Villain: {reader[0]}");

            }
            reader.Dispose();

            string minionsQuery = "SELECT Name, Age FROM Minions AS m" +
                                  "JOIN MinionsVillains AS mv ON m.Id = mv.MinionId" +
                                  "WHERE mv.VillainId = @villainId";

            var minionsCommand = new SqlCommand(minionsQuery, connection);

            minionsCommand.Parameters.AddWithValue("@villainId", villianId);

            reader = minionsCommand.ExecuteReader();
            int counter = 1;
            while (reader.Read())
            {
                Console.WriteLine($"{counter} {reader[0]} {reader[1]}");
        
                counter++;
            }
            reader.Dispose();
        }
       
    }
    static void ExecuteCommand(string command, SqlConnection connection)
    {
        var sql = new SqlCommand(command, connection);
        sql.ExecuteNonQuery();
    }
}
