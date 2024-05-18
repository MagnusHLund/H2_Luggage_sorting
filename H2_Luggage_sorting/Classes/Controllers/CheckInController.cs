using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class CheckInController
	{
		internal void ChangeCounterState(Counter counter)
		{
			// 0 = available, green color.
			// 1 = Processing, orange color.
			// 2 = Busy, orange color.
			counter.Status = 1;
		}
	}
}
