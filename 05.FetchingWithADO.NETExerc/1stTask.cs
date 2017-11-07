{
	var builder = new SqlConnectionStringBuilder()
	{
	["Server"] = ".",
	["Integrated Security"] = "true";
	};
	var connection = new SqlConnection(builder.ToString());

	connection.Open();
	using (connection)
	{
		try 
		{
		string createDbQuery = "CREATE DATABASE MinionsDB"
		ExecuteCommand(createDbQuery, connection);
		}	
		catch (Exception e)
		{
		Cosnole.Writeline(e.Message);
		}
	}
	builder.Add("Database", "MinionsDB");
	
	connection = new SqlConnection(builder.ToString());
	connection.Open();
	using (connection)
	{
		try 
		{
				//ADD HERE FROM MinionDB!!!!
		string createContriesSQL..... = "CREATE TABLE....";
		....
		....
		
		ExecuteCommand(createContriesSQL, connection);
		....
		......
		
		etc.
		}
		catch(Exception e)
		{
			Console.Writeline(e.Message);
		}
	
	}

}

static void ExecuteCommand(string command, SqlConnection connection)
{
	var sql = new SqlCommand(command, connection);
	sql.ExecuteNonQuery();
}
