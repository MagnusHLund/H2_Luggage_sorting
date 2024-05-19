namespace H2_Luggage_sorting.Classes.Models
{
    internal class Plane
	{
		#region Fields
		private protected string _flightId = "";
		internal string _airline = "";
		internal string _planeModel = "";
		private protected string _flightNumber = "";
		private protected DateTime _departureTime;
		#endregion

		#region Properties

		internal string FlightId 
        { 
            get { return _flightId; } 
        }
		internal string Airline
		{
			get { return _airline; }
		}
		internal string PlaneModel
		{
			get { return _planeModel; }
		}
        internal string FlightNumber
		{
			get { return _flightNumber; }
		}
		internal DateTime DepartureTime
		{
			get { return _departureTime; }
			set { _departureTime = value; }
		}

		#endregion

		#region Constructor

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
