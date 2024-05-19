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

		private void GetFlights()
		{
			var parameters = new Dictionary<string, object> { { "@input_date", _timeModel.GetDateTime().ToShortDateString() } };

			List<Dictionary<string, object>> fligthsData = new DatabaseConnection().CallProcedure("GetAllFlights", parameters);

			Plane[] planes = fligthsData.Select(row => new Plane(
				flightId: row[""].ToString(),
				airline: row[""].ToString(),
				planeModel: row[""].ToString(),
				flightNumber: row[""].ToString(),
				departureTime: Convert.ToDateTime(row[""])
			)).ToArray();

			_planesModel.AddFlights(planes);
		}

		#endregion
	}
}
