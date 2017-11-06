using System;
using System.Data.SqlClient;

namespace DBAppsDemo
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using ReaderDemo;

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

            using (connection)
            {
               var command = new SqlCommand(
                   "SELECT FirstName, LastName, JobTitle FROM Employees",
                   connection
                   );

                var people = new List<Person>();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var firstName = (string)reader["FirstName"];
                    var lastName = (string)reader["LastName"];
                    var jobTitle = (string)reader["JobTitle"];

                    var person = new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        JobTitle = jobTitle
                    };
                    people.Add(person);

                    //Console.WriteLine(person);
                }

                 var groupedPeople = people
                    .GroupBy(p => p.JobTitle)
                    .OrderByDescending(g => g.Count())
                    .ToList();

                foreach (var group in groupedPeople)
                {
                    Console.WriteLine($"{group.Key}: ");

                    foreach (var person in group)
                    {
                        Console.WriteLine(person);
                    }
                }

            }

        }
    }
}