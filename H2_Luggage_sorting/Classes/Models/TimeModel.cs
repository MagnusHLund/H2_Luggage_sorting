using System;

namespace H2_Luggage_sorting.Classes.Models
{
	/// <summary>
	/// Class to control the time flow of the airport.
	/// </summary>
	internal class TimeModel
	{
		// Fields to store time-related information
		#region Fields

		private protected int _month; // The month
		private protected int _day; // The day
		private protected int _year; // The year
		private protected int _ticks; // Ticks for time intervals

		// Date in the airport
		private protected DateTime _date; // The current date

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the TimeModel class with specific time parameters.
		/// </summary>
		/// <param name="month">The month.</param>
		/// <param name="day">The day.</param>
		/// <param name="year">The year.</param>
		/// <param name="ticks">The ticks for time intervals.</param>
		public TimeModel(int month, int day, int year, int ticks)
		{
			this._month = month;
			this._day = day;
			this._year = year;
			this._ticks = ticks;

			// Setting the given time to date
			DateTime date = new DateTime(_year, _month, _day);
			_date = date;
		}

		#endregion

		// Properties for accessing date and ticks
		#region Properties

		/// <summary>
		/// Gets or sets the current date.
		/// </summary>
		internal DateTime Date { get { return _date; } set { _date = value; } }

		/// <summary>
		/// Gets or sets the ticks for time intervals.
		/// </summary>
		internal int Ticks { get { return _ticks; } set { _ticks = value; } }

		#endregion
	}
}
