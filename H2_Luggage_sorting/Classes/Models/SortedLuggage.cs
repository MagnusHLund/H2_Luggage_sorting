using System;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class SortedLuggage
	{
		#region Properties

		internal string Gate { get; set; } // Property to store the gate where the luggage is sorted

		#endregion

		#region Constructor

		internal SortedLuggage(uint flightId, float weight, string gate)
		{
			this.Gate = gate; // Initialize the gate property with the provided value
		}

		#endregion
	}
}
