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

        const int ticks = 500;

        #endregion

        #region Constructors



        #endregion

        #region Methods
        public DateTime AddMinuteToDate(DateTime myDate)
        {
            myDate.AddMinutes(1);
            Thread.Sleep(ticks);

            return myDate;
        }
        #endregion
    }
}
