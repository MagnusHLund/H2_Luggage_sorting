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
        private Dictionary<uint, List<Luggage>> _sortedLuggage = new Dictionary<uint, List<Luggage>>();
        #endregion

        #region Properties
        internal List<Luggage> LuggageToSort
        {
            get => _luggageToSort;
            set => _luggageToSort = value;
        }

        internal Dictionary<uint, List<Luggage>> SortedLuggage
        {
            get => _sortedLuggage;
            set => _sortedLuggage = value;
        }
        #endregion
    }
}
