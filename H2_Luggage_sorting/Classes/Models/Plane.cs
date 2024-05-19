using H2_Luggage_sorting.Interfaces;

namespace H2_Luggage_sorting.Classes.Models
{
    public class Plane : IPlane
	{
		#region Fields
		private protected string _flightId = "";
		public string _airline = "";
		public string _planeModel = "";
		private protected string _flightNumber = "";
		private protected DateTime _departureTime;
		#endregion

		#region Properties

		public string FlightId 
        { 
            get { return _flightId; } 
        }
		public string Airline
		{
			get { return _airline; }
		}
		public string PlaneModel
		{
			get { return _planeModel; }
		}
        public string FlightNumber
		{
			get { return _flightNumber; }
		}
		public DateTime DepartureTime
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
