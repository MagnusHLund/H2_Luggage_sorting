using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Controllers
{
    internal class LuggageController
    {
        private LuggageModel _luggageModel = new LuggageModel();

        #region Constructor
        internal LuggageController(LuggageModel luggageModel)
        {
            _luggageModel = luggageModel;
        }
        #endregion

        #region Methods

        internal void SortLuggageToGate()
        {
            while (true)
            {
                if (_luggageModel.LuggageToSort.Count > 0)
                {
                    _luggageModel.SortedLuggage.Add(_luggageModel.LuggageToSort.First());
                    _luggageModel.LuggageToSort.Remove(_luggageModel.LuggageToSort.First());
                }
            }
        }
        #endregion
    }
} 
