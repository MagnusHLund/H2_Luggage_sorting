using System;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Plane
	{
		#region Fields

		private protected string _flightId = ""; // Unique identifier for the flight
		internal string _airline = ""; // Airline operating the flight
		internal string _planeModel = ""; // Model of the plane
		private protected string _flightNumber = ""; // Unique flight number
		private protected DateTime _departureTime; // Scheduled departure time

		#endregion

		#region Properties

		/// <summary>
		/// Gets the flight ID.
		/// </summary>
		internal string FlightId
		{
			get { return _flightId; }
		}

		/// <summary>
		/// Gets the airline.
		/// </summary>
		internal string Airline
		{
			get { return _airline; }
		}

		/// <summary>
		/// Gets the plane model.
		/// </summary>
		internal string PlaneModel
		{
			get { return _planeModel; }
		}

		/// <summary>
		/// Gets the flight number.
		/// </summary>
		internal string FlightNumber
		{
			get { return _flightNumber; }
		}

		/// <summary>
		/// Gets or sets the departure time.
		/// </summary>
		internal DateTime DepartureTime
		{
			get { return _departureTime; }
			set { _departureTime = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the Plane class.
		/// </summary>
		internal Plane(string flightId, string airline, string planeModel, string flightNumber, DateTime departureTime)
		{
			this._flightId = flightId;
			this._airline = airline;
			this._planeModel = planeModel;
			this._flightNumber = flightNumber;
			this._departureTime = departureTime;
		}

		#endregion

	}
}
