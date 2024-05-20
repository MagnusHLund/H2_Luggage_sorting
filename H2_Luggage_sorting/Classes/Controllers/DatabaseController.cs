using System.Configuration;
using MySql.Data.MySqlClient;

namespace H2_Luggage_sorting.Classes.Models
{
	/// <summary>
	/// Handles database connections and operations, specifically calling stored procedures.
	/// </summary>
	internal class DatabaseController
	{
		private string _connection;

		/// <summary>
		/// Initializes a new instance of the DatabaseController class and sets the connection string.
		/// </summary>
		internal DatabaseController()
		{
			_connection = ConfigurationManager.ConnectionStrings["AirportDatabase"].ConnectionString;
		}

		/// <summary>
		/// Calls a stored procedure in the database with optional parameters and returns the results as a list of dictionaries.
		/// </summary>
		/// <param name="procedureName">The name of the stored procedure to call.</param>
		/// <param name="parameters">Optional parameters to pass to the stored procedure.</param>
		/// <returns>A list of dictionaries, where each dictionary represents a row from the result set.</returns>
		internal List<Dictionary<string, object>> CallProcedure(string procedureName, Dictionary<string, object>? parameters = null)
		{
			parameters = parameters ?? new Dictionary<string, object>();
			var results = new List<Dictionary<string, object>>();

			using (MySqlConnection connection = new MySqlConnection(_connection))
			{
				using (MySqlCommand command = new MySqlCommand(procedureName, connection))
				{
					command.CommandType = System.Data.CommandType.StoredProcedure;

					// Add parameters to the command
					foreach (var param in parameters)
					{
						command.Parameters.AddWithValue(param.Key, param.Value);
					}

					connection.Open();
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						// Read each row from the result set
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
