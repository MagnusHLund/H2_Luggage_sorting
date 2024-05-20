using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class PlaneModel
	{
		#region Fields

		internal List<Plane> _planes = new List<Plane>(); // List to store planes

		#endregion Fields

		#region Properites

		/// <summary>
		/// Gets or sets the list of planes.
		/// </summary>
		internal List<Plane> Planes
		{
			get { return _planes; }
			set { _planes = value; }
		}

		#endregion
	}
}
