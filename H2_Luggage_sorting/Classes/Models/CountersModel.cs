namespace H2_Luggage_sorting.Classes.Models
{
	internal class CountersModel
	{
		private List<Counter> _counters = new List<Counter>(3);
		private List<Passenger> _unqueued = new List<Passenger>();

		private void AddPassengerToCounter()
		{
			foreach (Counter counter in _counters)
			{
				if(counter.Buffer.Count > counter.MaxQueueLength)
				{
					counter.Buffer.Add(_unqueued.First());
					_unqueued.Remove(_unqueued.First());
					return;
				}
			}
		}

		internal void AddPassengerToAirport(Passenger passenger)
		{
			_unqueued.Add(passenger);
		}

		internal void TryAddPassengersToCounter()
		{
			while(_unqueued.Count > 0 ) 
			{
				AddPassengerToCounter();
			}
		}

		internal List<Counter> GetCounters()
		{
			return _counters;
		}
	}
}
