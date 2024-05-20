using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class PlaneController
	{
		private readonly PlaneModel _planesModel;
		private readonly TimeModel _timeModel;

		/// <summary>
		/// Initializes a new instance of the PlaneController class with the provided plane and time models.
		/// </summary>
		/// <param name="planesModel">The plane model.</param>
		/// <param name="timeModel">The time model.</param>
		internal PlaneController(PlaneModel planesModel, TimeModel timeModel)
		{
			_planesModel = planesModel;
			_timeModel = timeModel;
		}

		/// <summary>
		/// Retrieves flights for the current date from the database and adds them to the plane model.
		/// </summary>
		internal void GetFlights()
		{
			var parameters = new Dictionary<string, object> { { "@input_date", _timeModel.Date.ToShortDateString() } };
			var flightsData = new DatabaseController().CallProcedure("GetAllFlights", parameters);

			var planes = flightsData.Select(row => new Plane(
				flightId: row["flight_id"].ToString(),
				airline: row["name"].ToString(),
				planeModel: row["model"].ToString(),
				flightNumber: row["flight_number"].ToString(),
				departureTime: Convert.ToDateTime(row["departure_time"])
			)).ToList();

			_planesModel.Planes.AddRange(planes);
		}
	}
}
