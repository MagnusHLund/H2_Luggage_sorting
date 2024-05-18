using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Luggage
	{
        #region Fields
        private protected uint _luggageId;
        private protected uint _flightId;
        private protected float _weight;
        #endregion


        #region Properties
        internal uint LuggageId { get; set; }
        internal uint FlightId { get; set; }
        internal float Weight { get; set; }
        #endregion  


        #region Constructor
        internal Luggage(uint luggageId, uint flightId, float Weight) 
        {
            this._luggageId = luggageId;
            this._weight = Weight;
            this._flightId = flightId;
        }

		#endregion
	}
}