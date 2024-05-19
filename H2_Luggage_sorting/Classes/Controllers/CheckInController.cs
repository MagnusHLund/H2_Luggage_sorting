
using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Threading;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class CheckInController
	{
		private TimeModel _timeModel;
		private PassengersModel _passengersModel;
		private CountersModel _countersModel;
		private LuggageModel _luggageModel;

		private TimeController _timeController;

		internal CheckInController(TimeModel timeModel, PassengersModel passengersModel, CountersModel countersModel, LuggageModel luggageModel, Dispatcher dispatch)
		{
			this._timeModel = timeModel;
			this._passengersModel = passengersModel;
			this._countersModel = countersModel;
			this._luggageModel = luggageModel;

			_timeController = new TimeController(_timeModel, null, null);
		}

		internal async void HandleCounters()
		{
			string currentDay = "";

			while (true) // TODO: This is very unoptimized, could have a while loop in MainWindow, starting this service once per new day.
			{
				if (currentDay != _timeModel.GetDateTime().ToShortDateString())
				{
					currentDay = _timeModel.GetDateTime().ToShortDateString();
					GetPassengers();
				}

				foreach(Passenger passenger in _passengersModel.GetPassengers())
				{
					_countersModel.AddPassengerToAirport(passenger);
				}

				_countersModel.TryAddPassengersToCounter();

				await _timeController.WaitForMinutesToPass(1);

				foreach (Counter counter in _countersModel.GetCounters())
				{
					Passenger passenger = counter.Buffer.First();

					_luggageModel.LuggageToSort.Add(passenger.Luggage);

					counter.Buffer.TryTake(out passenger);

					if(counter.Buffer.Count > 1)
					{
						counter.Status = "Busy";
					} else if (counter.Buffer.Count == 0)
					{
						counter.Status = "Available";
					}
				}
			}
		}

		private void GetPassengers()
		{
			var parameters = new Dictionary<string, object> { { "@input_date", _timeModel.GetDateTime().ToShortDateString() } };

			List<Dictionary<string, object>> passengersRawData = new DatabaseConnection().CallProcedure("GetPassengersByDepartureDate", parameters);

			Passenger[] passengers = passengersRawData.Select(row => new Passenger(
				firstName: row["first_name"].ToString(),
				lastName: row["last_name"].ToString(),
				flightId: Convert.ToUInt32(row["flight_id"]),
				luggage: RegisterLuggage(Convert.ToUInt32(row["flight_id"]))
			)).ToArray();

			_passengersModel.AddPassengers(passengers);
		}

		private static Luggage RegisterLuggage(uint flightId)
		{
			Random random = new Random();
			byte weight = (byte)random.Next(0, 24);

			return new Luggage(flightId, weight);
		}
	}
}
