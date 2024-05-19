 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class PassengersModel
	{
		private List<Passenger> _passengers = new List<Passenger>();

		internal void AddPassengers(Passenger[] passengers)
		{
			foreach (Passenger passenger in passengers) 
			{ 
				_passengers.Add(passenger);
			}
		}

		internal void RemovePassengers(Passenger[] passengers)
		{
			foreach(Passenger passenger in passengers)
			{
				_passengers.Remove(passenger);
			}
		}

		internal List<Passenger> GetPassengers()
		{
			return _passengers;
		}
	}
}
