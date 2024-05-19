using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class CountersModel
	{
		private Counter[] _counters = new Counter[3];
		private List<Passenger> _unqueued = new List<Passenger>();

		private void AddPassengerToCounter()
		{
			foreach (Counter counter in _counters)
			{
				if(counter.GetCounterQueueLength() > counter.GetMaxQueueCapacitiy())
				{
					counter.AddPassengerToQueue(_unqueued.First());
					_unqueued.Remove(_unqueued.First());
					return;
				}
			}
		}

		internal void AddPassengerToAirport(Passenger passenger)
		{
			_unqueued.Add(passenger);
		}
	}
}
