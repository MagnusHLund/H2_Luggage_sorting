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
        private List<Luggage> _sortedLuggage = new List<Luggage>();
        #endregion

        #region Properties
        internal List<Luggage> LuggageToSort
        {
            get { return _luggageToSort; }
            set { _luggageToSort = value; }
        }

        internal List<Luggage> SortedLuggage
        {
            get { return _sortedLuggage; }
            set { _sortedLuggage = value; }
        }
        #endregion
    }
}
