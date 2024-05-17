using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Luggage_sorting.Classes.Models;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class LuggageModel
	{
		#region Fields
		private List<Luggage> _luggageToSort = new List<Luggage>();
		#endregion

		#region Constructor 



		#endregion

		#region Methods

		internal List<Luggage> SortLuggage(List<Luggage> luggage)
		{
			return luggage;
 		}
		#endregion
	}
}
