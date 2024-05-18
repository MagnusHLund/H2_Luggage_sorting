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
        public TimeModel(int month, int day, int year)
        {
            this._month = month;
            this._day = day;
            this._year = year;

            // Setting the given time to date
            DateTime date = new DateTime(_year, _month, _day);
            _date = date;
        }

        #region Properties

        public int Second
        {
            get { return _second; }
            set { _second = value; }
        }

        public int Minute
        {
            get { return _minute; }
            set { _minute = value; }

        }

        public int Hour
        {
            get { return _hour; }
            set { _hour = value; }
        }

        public int Month
        {
            get { return _month; }
            set { _month = value; }
        }

        public int Day
        {
            get { return _day; }
            set { _day = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion
        #endregion

        #region Methods

        internal void AddMinutesToDateTime(int minutes)
        {
            _date = _date.AddMinutes(minutes);
        }

        internal DateTime GetDateTime()
        {
            return _date;   
        }

        #endregion
    }
}