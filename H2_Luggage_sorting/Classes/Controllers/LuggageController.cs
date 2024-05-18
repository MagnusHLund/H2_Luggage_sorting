using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Controllers
{
    internal class LuggageController
    {
        #region Fields
        private protected uint _id;
        private protected string _passenger;
        private protected uint _flight;
        private protected float _weight;
        #endregion

        #region Properties
        public uint Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Passenger
        {
            get { return _passenger; }
            set { _passenger = value; }
        }

        public uint Flight
        {
            get { return _flight; }
            set { _flight = value; }
        }
        public float Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
		#endregion

		#region Constructor
		public LuggageController(uint id, string passenger, uint flight, float weight)
		{
			_id = id;
			_passenger = passenger;
			_flight = flight;
			_weight = weight;
		}
		#endregion

		#region Methods

		public static void GenerateLuggage(List<Passenger> passengers)
        {
            uint luggageId = 1;

            foreach (var passenger in passengers)
            {
                Luggage luggage = new Luggage(
                    luggageId,
                    passenger.FlightId,  // Using FlightId
					passenger.Luggage.Weight // Accessing weight from the Luggage object
				);

                luggageId++;
            }
        }

        #endregion
    }
} 
