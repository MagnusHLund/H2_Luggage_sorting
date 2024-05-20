using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class PassengersModel
	{
		#region Fields

		private List<Passenger> _passengers = new List<Passenger>(); // List to store passengers

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the list of passengers.
		/// </summary>
		internal List<Passenger> Passengers
		{
			get { return _passengers; }
			set { _passengers = value; }
		}

		#endregion
	}
}
