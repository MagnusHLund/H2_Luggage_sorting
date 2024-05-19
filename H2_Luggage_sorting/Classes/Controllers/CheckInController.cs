using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class CheckInController
	{
		private TimeModel _timeModel;
		private PassengersModel _passengersModel;
		private CountersModel _countersModel;

		internal CheckInController(TimeModel timeModel, PassengersModel passengersModel, CountersModel countersModel)
		{
			this._timeModel = timeModel;
			this._passengersModel = passengersModel;
			this._countersModel = countersModel;
		}

		internal void HandleCounters()
		{
			while (true)
			{
				if (_timeModel.IsMidnight())
				{
					// Get passengers
					List<Dictionary<string, object>> passengersRawData = new DatabaseConnection().CallProcedure("GetPassengersByDepartureDate");

					Passenger[] passengers = passengersRawData.Select(row => new Passenger(
						firstName: row["first_name"].ToString(),
						lastName: row["last_name"].ToString(),
						flightId: Convert.ToUInt32(row["flight_id"]),
						luggage: new Luggage(1, 1, 1)
					)).ToArray();

				}

				while (_passengersModel.GetPassengers().Count > 0)
				{

				}
			}
		}
	}
}
