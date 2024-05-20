namespace H2_Luggage_sorting.Classes.Models
{
	internal class CountersModel
	{
		private List<Counter> _counters; // List to store counters
		private List<Passenger> _unqueued = new List<Passenger>(); // List to store unqueued passengers

		// Constructor to initialize the CountersModel with a list of counters
		internal CountersModel(List<Counter> counters)
		{
			_counters = counters;
		}

		// Property to get or set the list of counters
		internal List<Counter> Counters
		{
			get { return _counters; }
			set { _counters = value; }
		}

		// Property to get or set the list of unqueued passengers
		internal List<Passenger> Unqueued
		{
			get { return _unqueued; }
			set { _unqueued = value; }
		}
	}
}
