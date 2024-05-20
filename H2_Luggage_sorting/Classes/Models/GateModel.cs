using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class GateModel
	{
		#region Fields

		private List<Gate> _gates = new List<Gate>(3); // List to store gates with an initial capacity of 3

		#endregion

		#region Properties

		/// <summary>
		/// Gets the list of gates.
		/// </summary>
		internal List<Gate> Gates
		{
			get { return _gates; }
		}

		#endregion

	}
}
