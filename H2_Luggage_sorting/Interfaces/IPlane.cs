using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Interfaces
{
    public interface IPlane
	{
        public string FlightId { get; }
        public string Airline {  get; }
        public string PlaneModel { get; }
        public string FlightNumber { get; } 
        public DateTime DepartureTime { get; set; }
	}
}
