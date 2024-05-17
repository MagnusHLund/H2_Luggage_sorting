using System.Configuration;
using MySql.Data.MySqlClient;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class DatabaseConnection
	{
		private string _connection;

		internal DatabaseConnection() 
		{
			_connection = ConfigurationManager.ConnectionStrings["MyKey"].ConnectionString;
		}

		internal void CallProcedure(string procedureName, string[] args)
		{
			using (MySqlConnection connection = new MySqlConnection(_connection))
			{
				using (MySqlCommand command = new MySqlCommand(procedureName, connection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;

					for (int i = 0; i < args.Length; i++)
					{
						command.Parameters.AddWithValue($"@param{i + 1}", args[i]);
					}
				}
			}
		}
	}
}
