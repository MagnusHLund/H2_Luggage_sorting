using H2_Luggage_sorting.Classes.Models;
using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Threading;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class TimeController
	{
		#region Fields
		private TimeModel _timeModel;
		private Dispatcher _dispatcher;
		private TextBlock _clockElement;
		private readonly object _lock = new object(); // Lock object
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the TimeController class with the provided time model, dispatcher, and clock element.
		/// </summary>
		/// <param name="timeModel">The time model.</param>
		/// <param name="dispatcher">The dispatcher for UI updates.</param>
		/// <param name="clock">The clock element for displaying time.</param>
		internal TimeController(TimeModel timeModel, Dispatcher? dispatcher, TextBlock? clock)
		{
			this._timeModel = timeModel;
			this._dispatcher = dispatcher;
			this._clockElement = clock;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Adds the specified number of minutes to the current date repeatedly.
		/// </summary>
		/// <param name="minutes">The number of minutes to add.</param>
		/// <returns>The updated date.</returns>
		internal DateTime AddMinutesToDate(int minutes)
		{
			while (true)
			{
				lock (_lock) // Ensure that this section is thread-safe
				{
					_timeModel.Date = _timeModel.Date.AddMinutes(minutes);
				}

				Thread.Sleep(_timeModel.Ticks);

				_dispatcher?.Invoke(() =>
				{
					lock (_lock) // Ensure that the UI update is thread-safe
					{
						_clockElement.Text = _timeModel.Date.ToString();
					}
				});
			}
		}

		/// <summary>
		/// Waits for the specified number of minutes to pass asynchronously.
		/// </summary>
		/// <param name="minutesToWait">The number of minutes to wait.</param>
		/// <returns>An asynchronous task.</returns>
		internal async Task WaitForMinutesToPass(int minutesToWait)
		{
			DateTime target;
			lock (_lock) // Ensure that reading _timeModel.Date is thread-safe
			{
				target = _timeModel.Date.AddMinutes(minutesToWait);
			}

			while (true)
			{
				DateTime currentTime;
				lock (_lock) // Ensure that reading _timeModel.Date is thread-safe
				{
					currentTime = _timeModel.Date;
				}

				if (currentTime >= target) break;

				await Task.Delay(_timeModel.Ticks);
			}
		}
		#endregion
	}
}
