using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace H2_Luggage_sorting.Classes.Controllers
{
	/// <summary>
	/// Manages the check-in process for passengers, including handling counters, adding passengers, and updating counter statuses.
	/// </summary>
	internal class CheckInController
	{
		private readonly TimeModel _timeModel;
		private readonly PassengersModel _passengersModel;
		private readonly CountersModel _countersModel;
		private readonly LuggageModel _luggageModel;
		private readonly TimeController _timeController;

		private readonly object _lockObject = new object();

		/// <summary>
		/// Initializes a new instance of the CheckInController class with the provided models and dispatcher.
		/// </summary>
		/// <param name="timeModel">The time model.</param>
		/// <param name="passengersModel">The passengers model.</param>
		/// <param name="countersModel">The counters model.</param>
		/// <param name="luggageModel">The luggage model.</param>
		/// <param name="dispatcher">The dispatcher for UI updates.</param>
		internal CheckInController(TimeModel timeModel, PassengersModel passengersModel, CountersModel countersModel, LuggageModel luggageModel, Dispatcher dispatcher)
		{
			_timeModel = timeModel;
			_passengersModel = passengersModel;
			_countersModel = countersModel;
			_luggageModel = luggageModel;
			_timeController = new TimeController(_timeModel, dispatcher, null);
		}

		/// <summary>
		/// Handles counter operations asynchronously by continuously checking and updating passenger queues and counter statuses.
		/// </summary>
		internal async Task HandleCounters()
		{
			string currentDay = string.Empty; // Track the current day
			while (true) // Infinite loop to continuously handle counters
			{
				try
				{
					// Get today's date and load passengers for the new day if it has changed
					var today = _timeModel.Date.ToShortDateString();
					if (currentDay != today)
					{
						currentDay = today;
						GetPassengersFromDatabase();
					}

					lock (_lockObject)
					{
						// Add each passenger to the airport's unqueued list
						foreach (var passenger in _passengersModel.Passengers.ToList())
						{
							AddPassengerToAirport(passenger);
						}

						// Try to add passengers to available counters
						TryAddPassengersToCounter();
					}

					// Wait for a minute before repeating the process
					await _timeController.WaitForMinutesToPass(1);
				}
				catch (Exception ex)
				{
					// Show any exception message in a message box
					MessageBox.Show(ex.Message);
				}
			}
		}

		/// <summary>
		/// Retrieves passengers from the database based on the current date and updates the passengers model.
		/// </summary>
		private void GetPassengersFromDatabase()
		{
			var parameters = new Dictionary<string, object> { { "@input_date", _timeModel.Date.ToShortDateString() } };
			var passengersRawData = new DatabaseController().CallProcedure("GetPassengersByDepartureDate", parameters);

			// Convert raw data to Passenger objects and register their luggage
			var passengers = passengersRawData.Select(row => new Passenger(
				firstName: row["first_name"].ToString(),
				lastName: row["last_name"].ToString(),
				flightId: Convert.ToUInt32(row["flight_id"]),
				luggage: RegisterLuggage(Convert.ToUInt32(row["flight_id"]))
			)).ToList();

			lock (_lockObject)
			{
				_passengersModel.Passengers.AddRange(passengers); // Add passengers to the model
			}
		}

		/// <summary>
		/// Creates and returns a Luggage object with a random weight for a given flight ID.
		/// </summary>
		/// <param name="flightId">The flight ID associated with the luggage.</param>
		/// <returns>A new Luggage object with a random weight.</returns>
		private static Luggage RegisterLuggage(uint flightId)
		{
			var random = new Random();
			byte weight = (byte)random.Next(0, 24); // Random weight between 0 and 23
			return new Luggage(flightId, weight);
		}

		/// <summary>
		/// Adds a passenger to the airport's unqueued list.
		/// </summary>
		/// <param name="passenger">The passenger to add.</param>
		private void AddPassengerToAirport(Passenger passenger)
		{
			lock (_lockObject)
			{
				_countersModel.Unqueued.Add(passenger);
			}
		}

		/// <summary>
		/// Attempts to add unqueued passengers to available counters.
		/// </summary>
		private void TryAddPassengersToCounter()
		{
			lock (_lockObject)
			{
				while (_countersModel.Unqueued.Any())
				{
					AddPassengerToCounter(); // Add passengers one by one to counters
				}
			}
		}

		/// <summary>
		/// Adds a single passenger to an available counter if there is space.
		/// </summary>
		private void AddPassengerToCounter()
		{
			lock (_lockObject)
			{
				foreach (var counter in _countersModel.Counters)
				{
					if (counter.Buffer.Count < counter.MaxQueueLength) // Check if counter has space
					{
						var passenger = _countersModel.Unqueued.First(); // Get the first unqueued passenger
						_countersModel.Unqueued.Remove(passenger); // Remove from unqueued list
						counter.Buffer.Add(passenger); // Add to the counter's buffer
						_luggageModel.LuggageToSort.Add(passenger.Luggage); // Add luggage to sorting list

						// Update the counter's status to "Available"
						UpdateCounterStatus(counter, "Available");
						break; // Exit the loop after adding the passenger
					}
				}
			}
		}

		/// <summary>
		/// Updates the status and image of a counter based on its current status.
		/// </summary>
		/// <param name="counter">The counter to update.</param>
		/// <param name="status">The new status of the counter.</param>
		internal void UpdateCounterStatus(Counter counter, string status)
		{
			counter.Status = status;

			// Set the counter's image based on its status
			switch (status)
			{
				case "Available":
					counter.ImageSource = new BitmapImage(new Uri("/Images/CounterGreen.png", UriKind.Relative));
					break;
				case "Busy":
					counter.ImageSource = new BitmapImage(new Uri("/Images/CounterOrange.png", UriKind.Relative));
					break;
			}
		}
	}
}
