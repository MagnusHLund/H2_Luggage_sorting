using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Passenger 
	{
		#region Properties
		internal string FirstName { get; }
		internal string LastName { get; }
		internal uint FlightId { get; }
		internal Luggage Luggage {  get; }
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