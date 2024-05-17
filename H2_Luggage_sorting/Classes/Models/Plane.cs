using H2_Luggage_sorting.Interfaces;

namespace H2_Luggage_sorting.Classes.Models
{
    public class Plane : IPlane
	{
		#region Fields

		private protected string _planeId = "";
		public string _airline = "";
		public string _planeModel = "";
		private protected string _flightId = "";
		private protected string _departureTime = "";
		private protected uint _weightLimit;
        private protected uint _totalWeight;
		public ushort _availableSeats;
		#endregion

		#region Properties

		public string PlaneId 
        { 
            get { return _planeId; } 
        }
		public string Airline
		{
			get { return _airline; }
		}
		public string PlaneModel
		{
			get { return _planeModel; }
		}
        public string FlightId
		{
			get { return _flightId; }
		}
		public string DepartureTime
		{
			get { return _departureTime; }
			set { _departureTime = value; }
		}
		public uint WeightLimit
		{
			get { return _weightLimit; }
		}
		public uint TotalWeight
		{
			get { return _totalWeight; }
			set { _totalWeight = value; }
		}

		public ushort AvailableSeats
		{
			get { return _availableSeats; _availableSeats; }
			set { _availableSeats = value;}
			set { _availableSeats = value; }
		}

		#endregion

		public void DepartPlane() 
		{ 

		}
	}
}
