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
		private Dispatcher _dispatcher;
		private TextBlock _clockElement;

		#endregion

		#region Constructors
		internal TimeController(TimeModel timeModel, Dispatcher? dispatcher, TextBlock? clock)
		{
			this._timeModel = timeModel;
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
				Thread.Sleep(_timeModel.GetTicks());

				_dispatcher.Invoke(() =>
				{
					_clockElement.Text = _timeModel.GetDateTime().ToString();
				});
			}
        }

		internal async Task WaitForMinutesToPass(int minutesToWait)
		{
			DateTime target = _timeModel.GetDateTime();
			target.AddMinutes(minutesToWait);

			while(target > _timeModel.GetDateTime())
			{
				await Task.Delay(_timeModel.GetTicks());
			}
		}
        #endregion
    }
}