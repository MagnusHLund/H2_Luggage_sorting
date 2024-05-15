using H2_Luggage_sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Model
{
	internal abstract class Plane : IPlane
	{
		#region Fields
		private protected string _planeId;
		private protected string _flightId;
		private protected string _departureTime;
		private protected string _planeWeightLimit;
		#endregion
	}
}
