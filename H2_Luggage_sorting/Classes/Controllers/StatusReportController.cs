using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class StatusReportController
	{
		#region Fields

		private protected TimeModel _timeModel;
		private protected PlaneModel _planeModel;
		private protected LuggageModel _luggageModel;

		static string directory = Environment.CurrentDirectory;
		#endregion


		#region Constructor
		/// <summary>
		/// Initializes a new instance of the StatusReportController class with the provided plane, time, and luggage models.
		/// </summary>
		/// <param name="planeModel">The plane model.</param>
		/// <param name="timeModel">The time model.</param>
		/// <param name="luggageModel">The luggage model.</param>
		internal StatusReportController(PlaneModel planeModel, TimeModel timeModel, LuggageModel luggageModel)
		{
			this._planeModel = planeModel;
			this._timeModel = timeModel;
			this._luggageModel = luggageModel;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Generates a status report text file with information about planes and their luggage.
		/// </summary>
		internal void GenerateStatusReport()
		{
			string currentTime = _timeModel.Date.ToShortDateString();

			while (true)
			{
				if (currentTime != _timeModel.Date.ToShortDateString())
				{
					// Sets the time to the previous day
					currentTime = _timeModel.Date.AddDays(-1).ToShortDateString();

					string path = $"{directory}/StatusReport-{currentTime}.txt";
					StringBuilder reportContent = new StringBuilder();

					// Write information to the daily log file
					foreach (Plane plane in _planeModel.Planes)
					{
						reportContent.AppendLine("Status Report");
						reportContent.AppendLine("-------------");
						reportContent.AppendLine($"Flight ID: {plane.FlightId}");
						reportContent.AppendLine($"Plane Model: {plane.PlaneModel}");
						reportContent.AppendLine($"Departure Time: {plane.DepartureTime}");
						reportContent.AppendLine();
						reportContent.AppendLine("Luggage List:");
						reportContent.AppendLine("-------------");
					}

					foreach (Luggage luggage in _luggageModel.SortedLuggage)
					{
						reportContent.AppendLine($"Weight: {luggage.Weight}");
					}

					File.WriteAllText(path, reportContent.ToString());
				}

			}


		}

		#endregion
	}
}
