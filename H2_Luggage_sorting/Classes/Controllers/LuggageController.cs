using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Controllers
{
    internal class LuggageController
    {
        private LuggageModel _luggageModel = new LuggageModel();

        #region Constructor
        public LuggageController(LuggageModel luggageModel)
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
                    List<Luggage> luggageToRemove = new List<Luggage>();

                    foreach (Luggage luggage in _luggageModel.LuggageToSort)
                    {
                        if (!_luggageModel.SortedLuggage.ContainsKey(luggage.FlightId))
                        {
                            _luggageModel.SortedLuggage[luggage.FlightId] = new List<Luggage>();
                        }

                        _luggageModel.SortedLuggage[luggage.FlightId].Add(luggage);
                        luggageToRemove.Add(luggage);
                    }

                    foreach (Luggage luggage in luggageToRemove)
                    {
                        _luggageModel.LuggageToSort.Remove(luggage);
                    }
                }
            }
        }
        #endregion
    }
} 
