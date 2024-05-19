using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class PlaneController
	{
		#region Methods 

		private PlaneModel _planesModel;
		private TimeModel _timeModel;

		internal PlaneController(PlaneModel planesModel, TimeModel timeModel)
		{
			_planesModel = planesModel;
			_timeModel = timeModel;
		}

		internal void GetFlights()
		{
			var parameters = new Dictionary<string, object> { { "@input_date", _timeModel.GetDateTime().ToShortDateString() } };

			List<Dictionary<string, object>> flightsData = new DatabaseConnection().CallProcedure("GetAllFlights", parameters);

			Plane[] planes = flightsData.Select(row => new Plane(
				flightId: row["flight_id"].ToString(),
				airline: row["name"].ToString(),
				planeModel: row["model"].ToString(),
				flightNumber: row["flight_number"].ToString(),
				departureTime: Convert.ToDateTime(row["departure_time"])
			)).ToArray();

			_planesModel.AddFlights(planes);
		}

		#endregion
	}
}
