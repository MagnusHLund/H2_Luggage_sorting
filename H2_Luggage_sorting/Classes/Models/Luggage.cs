using System;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Luggage
	{
		#region Fields

		private protected uint _flightId; // The ID of the flight associated with the luggage
		private protected float _weight; // The weight of the luggage

		#endregion


		#region Properties

		/// <summary>
		/// Gets or sets the ID of the flight associated with the luggage.
		/// </summary>
		internal uint FlightId
		{
			get { return _flightId; }
			set { _flightId = value; }
		}

		/// <summary>
		/// Gets or sets the weight of the luggage.
		/// </summary>
		internal float Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}

		#endregion


		#region Constructor

		/// <summary>
		/// Initializes a new instance of the Luggage class with the specified flight ID and weight.
		/// </summary>
		/// <param name="flightId">The ID of the flight associated with the luggage.</param>
		/// <param name="weight">The weight of the luggage.</param>
		internal Luggage(uint flightId, float weight)
		{
			_flightId = flightId;
			_weight = weight;
		}

		#endregion
	}
}
