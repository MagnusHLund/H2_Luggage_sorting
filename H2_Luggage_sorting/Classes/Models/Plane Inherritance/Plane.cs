using H2_Luggage_sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    public abstract class Plane : IPlane
	{
		#region Fields

		private protected string _planeId;
		private protected string _flightId;
		private protected string _departureTime;
		private protected string _weightLimit;

        #endregion

        #region Properties

        public string PlaneId { get; }
        public string FlightId { get; }
        public string DepartureTime { get; set; }
        public string WeightLimit { get; }

        #endregion
    }
}
