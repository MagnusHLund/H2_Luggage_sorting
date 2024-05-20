using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class LuggageModel
	{
		#region Fields

		private List<Luggage> _luggageToSort = new List<Luggage>(); // List to store luggage items to be sorted
		private List<Luggage> _sortedLuggage = new List<Luggage>(); // List to store sorted luggage items

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the list of luggage items to be sorted.
		/// </summary>
		internal List<Luggage> LuggageToSort
		{
			get { return _luggageToSort; }
			set { _luggageToSort = value; }
		}

		/// <summary>
		/// Gets or sets the list of sorted luggage items.
		/// </summary>
		internal List<Luggage> SortedLuggage
		{
			get { return _sortedLuggage; }
			set { _sortedLuggage = value; }
		}

		#endregion
	}
}
