using System;
using System.Data.SqlClient;

namespace DBAppsDemo
{
    using System.Xml.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var connection = new SqlConnection(
                "Server=Niki\\SQLEXPRESS;" + //or "Server=Niki\SQLEXPRESS"
                "Database=SoftUni;" +
                "Integrated Security=True"
                );

            connection.Open();

            Console.Write("Enter the town wich you want to be deleted: ");
            var townName = Console.ReadLine();


            using (connection)
            {
                var transaction = connection.BeginTransaction();

                var command = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);

                var command2 = new SqlCommand("SELECT SUM(Salary) FROM Employees", connection);

                var command3 = new SqlCommand($"INSERT INTO Towns (Name) VALUES ('{townName}')", connection);

                var command4 = new SqlCommand($"DELETE FROM Towns WHERE Name = ('{townName}')", 
                                              connection,
                                              transaction);


                var count = (int)command.ExecuteScalar();
                Console.WriteLine($"Employee Count: {count}");

                var sum = (decimal)command2.ExecuteScalar();
                Console.WriteLine($"Employee Summed Salaries: {sum}");

                var insertVratsa = (int)command3.ExecuteNonQuery();
                Console.WriteLine($"Rows affected: {insertVratsa}");

                var deleteTown = command4.ExecuteNonQuery();

                transaction.Rollback();

                Console.WriteLine($"Rows affected: {deleteTown}");

            }

            //connection.Close(); - if it's without using ( .....


        }
    }
}