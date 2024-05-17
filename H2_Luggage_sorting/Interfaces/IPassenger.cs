using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Interfaces
{
	interface IPassenger
	{
		public string FirstName { get; }
		public string LastName { get; }
		public uint FlightId { get; }
	}
}
