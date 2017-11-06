using System;
using System.Data.SqlClient;

public class InjParam

{
    static void Main()
    {
        var connection = new SqlConnection(
            "Server=Niki\\SQLEXPRESS;" + //or "Server=Niki\SQLEXPRESS"
            "Database=SoftUni;" +
            "Integrated Security=True"
        );

        connection.Open();

        var userName = Console.ReadLine();
        var password = Console.ReadLine();
   
        var isPasswordValid = IsPasswordValid(userName, password, connection);
    }





    private static bool IsPasswordValid (string userName, string password, SqlConnection connection)
    {
        //string sql =
        //        $"SELECT COUNT(*) FROM Users " +
        //        $"WHERE UserName = '{userName}' AND" +
        //        $"PasswordHash = (SELECT dbo.SHA1{password})";


        //this above is vunarable to SQL Inj


        //SELECT COUNT(*) FROM USERS WHERE UserName = '' OR 1=1 //returns all users!
        //SELECT COUNT(*) FROM USERS WHERE UserName = ''; PRINT N'Opa!';
        //SELECT COUNT(*) FROM Employees WHERE FirstName = ''; PRINT N'Opa'; --';

        //it has to be:
        string sql =
            $"SELECT COUNT(*) FROM Users " +
            $"WHERE UserName = @userName AND" +
            $"PasswordHash = (SELECT dbo.SHA1(@password)";


        SqlCommand cmd = new SqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("userName", userName);
        cmd.Parameters.AddWithValue("@password", password);

        int matchedUsersCount = (int)cmd.ExecuteScalar();
        return matchedUsersCount > 0;
    }
}
