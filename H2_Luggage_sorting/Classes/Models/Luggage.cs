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
        private protected string _luggageId;
        private protected float _luggageWeight;
		#endregion

		#region Constructor
		internal Luggage(string luggageId, float luggageWeight) 
        {
            this._luggageId = luggageId;
            this._luggageWeight = luggageWeight;
        }
		#endregion
	}
}