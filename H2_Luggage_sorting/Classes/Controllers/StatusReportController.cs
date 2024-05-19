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
		internal StatusReportController(PlaneModel planeModel, TimeModel timeModel, LuggageModel luggageModel)
		{
			this._planeModel = planeModel;
			this._timeModel = timeModel;
			this._luggageModel = luggageModel;
		}
		#endregion

		#region Methods
		internal void GenerateStatusReport()
		{
			string currentTime = _timeModel.GetDateTime().ToShortDateString();

			while (true)
			{
				if (currentTime != _timeModel.GetDateTime().ToShortDateString())
				{
					currentTime = _timeModel.GetDateTime().ToShortDateString();

					string path = $"{directory}/StatusReport-{currentTime}.txt";
					StringBuilder reportContent = new StringBuilder();

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
