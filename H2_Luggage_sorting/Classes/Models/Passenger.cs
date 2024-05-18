using H2_Luggage_sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Passenger : IPassenger
	{
		#region Properties
		public string FirstName { get; }
		public string LastName { get; }
		public uint FlightId { get; }
		public Luggage Luggage {  get; }
        #endregion

        #region Constructors

		internal Passenger(string firstName, string lastName, uint flightId, Luggage luggage)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.FlightId = flightId;
			this.Luggage = luggage;
		}

        #endregion
    }
}