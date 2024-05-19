using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace H2_Luggage_sorting.Classes.Controllers
{
    internal class TimeController
    {
		#region Fields
		private TimeModel _timeModel;
		private int _ticks;
		private Dispatcher _dispatcher;
		private TextBlock _clockElement;

		#endregion

		#region Constructors
		internal TimeController(TimeModel timeModel, int ticks, Dispatcher dispatcher, TextBlock clock)
		{
			this._timeModel = timeModel;
			this._ticks = ticks;
			this._dispatcher = dispatcher;
			this._clockElement = clock;
		}
		#endregion

		#region Methods
		internal DateTime AddMinutesToDate(int minutes)
        {
			while(true)
			{
				_timeModel.AddMinutesToDateTime(minutes);
				Thread.Sleep(_ticks);

				_dispatcher.Invoke(() =>
				{
					_clockElement.Text = _timeModel.GetDateTime().ToString();
				});
			}
        }
        #endregion
    }
}