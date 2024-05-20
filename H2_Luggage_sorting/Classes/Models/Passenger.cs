using System;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Passenger
	{
		#region Fields

		private protected string _firstName; // The first name of the passenger
		private protected string _lastName; // The last name of the passenger
		private protected uint _flightId; // The ID of the flight associated with the passenger
		private protected Luggage _luggage; // The luggage of the passenger

		#endregion

		#region Properties

		/// <summary>
		/// Gets the first name of the passenger.
		/// </summary>
		internal string FirstName { get { return _firstName; } }

		/// <summary>
		/// Gets the last name of the passenger.
		/// </summary>
		internal string LastName { get { return _lastName; } }

		/// <summary>
		/// Gets the ID of the flight associated with the passenger.
		/// </summary>
		internal uint FlightId { get { return _flightId; } }

		/// <summary>
		/// Gets the luggage of the passenger.
		/// </summary>
		internal Luggage Luggage { get { return _luggage; } }

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the Passenger class with the specified details.
		/// </summary>
		/// <param name="firstName">The first name of the passenger.</param>
		/// <param name="lastName">The last name of the passenger.</param>
		/// <param name="flightId">The ID of the flight associated with the passenger.</param>
		/// <param name="luggage">The luggage of the passenger.</param>
		internal Passenger(string firstName, string lastName, uint flightId, Luggage luggage)
		{
			_firstName = firstName;
			_lastName = lastName;
			_flightId = flightId;
			_luggage = luggage;
		}

		#endregion
	}
}
