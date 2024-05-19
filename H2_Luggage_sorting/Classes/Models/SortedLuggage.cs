using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class SortedLuggage
	{

		#region Properties
		internal string Gate {  get; set; }
		#endregion

		#region Constructor

		internal SortedLuggage(uint flightId, float weight, string gate)
		{
			this.Gate = gate;
		}
		#endregion
	}
}
