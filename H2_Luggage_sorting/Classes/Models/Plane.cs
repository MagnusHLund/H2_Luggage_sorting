using H2_Luggage_sorting.Interfaces;

namespace H2_Luggage_sorting.Classes.Models
{
    public class Plane : IPlane
	{
		#region Fields

		private protected string _planeId = "";
		private protected string _flightId = "";
		private protected string _departureTime = "";
		private protected uint _weightLimit;
        private protected uint _totalWeight;
        #endregion

        #region Properties

        public string PlaneId 
        { 
            get { return _planeId; } 
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

		#endregion

		public void DepartPlane() 
		{ 

		}
	}
}
