using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
    internal class TimeController
    {
        #region Fields
        private TimeModel _timeModel = new TimeModel(6, 1, 2024);
        const int ticks = 500; // half a second

        #endregion

        #region Constructors



        #endregion

        #region Methods
        public DateTime AddMinuteToDate(int minutes)
        {
            _timeModel.AddMinutesToDateTime(minutes);
            Thread.Sleep(ticks);

            return _timeModel.GetDateTime();
        }
        #endregion
    }
}