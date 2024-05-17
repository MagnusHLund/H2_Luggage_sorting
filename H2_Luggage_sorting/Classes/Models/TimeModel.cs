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

        private protected int _second;
        private protected int _minute;
        private protected int _hour;

        private protected int _month;
        private protected int _day;
        private protected int _year;

        // Date in the airport
        private protected DateTime _date;

        #endregion

        #region Constructors

        /// <summary>
        /// When initiating a new instance of time model, you will need to give specific time parameters.
        /// </summary>
        /// <param name="second"></param>
        /// <param name="minute"></param>
        /// <param name="hour"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <param name="year"></param>
        public TimeModel(int second, int minute, int hour, int month, int day, int year) 
        {
            this._second = second;
            this._minute = minute;
            this._hour = hour;

            this._month = month;
            this._day = day;
            this._year = year;
            
            // Setting the given time to date
            DateTime myDate = new DateTime(_year, _month, _day, _hour, _minute, _second);
            _date = myDate;
        }

        #endregion

        #region Methods

        #endregion
    }
}
