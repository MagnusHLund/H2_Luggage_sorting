using System.Configuration;
using MySql.Data.MySqlClient;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class DatabaseConnection
	{
		private string _connection;

		internal DatabaseConnection()
		{
			_connection = ConfigurationManager.ConnectionStrings["AirportDatabase"].ConnectionString;
		}

		internal List<Dictionary<string, object>> CallProcedure(string procedureName, Dictionary<string, object>? parameters = null)
		{
			parameters = parameters ?? new Dictionary<string, object>();
			var results = new List<Dictionary<string, object>>();

			using (MySqlConnection connection = new MySqlConnection(_connection))
			{
				using (MySqlCommand command = new MySqlCommand(procedureName, connection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;

					foreach (var param in parameters)
					{
						command.Parameters.AddWithValue(param.Key, param.Value);
					}

					connection.Open();
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							var row = new Dictionary<string, object>();
							for (int i = 0; i < reader.FieldCount; i++)
							{
								row[reader.GetName(i)] = reader.GetValue(i);
							}
							results.Add(row);
						}
					}
				}
			}

			return results;
		}


	}
}
