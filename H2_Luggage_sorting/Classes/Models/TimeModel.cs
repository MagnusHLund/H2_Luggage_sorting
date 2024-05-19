using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    /// <summary>
    /// Class to control the timeflow of the airport.
    /// </summary>
    internal class TimeModel
    {
        // Creating fields for saving the time in the airport
        #region Fields

        private protected int _month;
        private protected int _day;
        private protected int _year;
        private protected int _ticks;

        // Date in the airport
        private protected DateTime _date;

        #endregion

        #region Constructor

        /// <summary>
        /// When initiating a new instance of time model, you will need to give specific time parameters.
        /// </summary>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
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

        #region Methods

        internal void AddMinutesToDateTime(int minute)
        {
            _date = _date.AddMinutes(minute);
        }

        internal DateTime GetDateTime()
        {
            return _date;   
        }

		internal int GetTicks()
		{
			return _ticks;
		}

		#endregion
	}
}