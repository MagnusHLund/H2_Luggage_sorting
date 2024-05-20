using System;

namespace H2_Luggage_sorting.Classes.Models
{
	/// <summary>
	/// This class represents a gate and its associated properties.
	/// </summary>
	internal class Gate
	{
		// Constant representing the number of hours before departure that a gate opens
		internal const int GATE_OPENING_TIME_BEFORE_DEPARTURE = -1;

		#region Fields

		private byte _gateNumber; // The number of the gate
		private bool _isGateOpen; // Indicates whether the gate is open
		private Plane _plane; // The plane assigned to the gate
		private DateTime _gateOpeningTime; // The calculated time when the gate opens

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Gate class with the specified gate number, gate status, and assigned plane.
		/// </summary>
		/// <param name="gateNumber">The number of the gate.</param>
		/// <param name="isGateOpen">Indicates whether the gate is open.</param>
		/// <param name="plane">The plane assigned to the gate.</param>
		internal Gate(byte gateNumber, bool isGateOpen, Plane plane)
		{
			_gateNumber = gateNumber;
			_isGateOpen = isGateOpen;
			_plane = plane;
			// Calculate the gate opening time based on the departure time of the assigned plane
			DateTime departureTime = plane.DepartureTime.AddHours(GATE_OPENING_TIME_BEFORE_DEPARTURE);
			_gateOpeningTime = departureTime;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the number of the gate.
		/// </summary>
		internal byte GateNumber
		{
			get { return _gateNumber; }
			set { _gateNumber = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether the gate is open.
		/// </summary>
		internal bool IsGateOpen
		{
			get { return _isGateOpen; }
			set { _isGateOpen = value; }
		}

		/// <summary>
		/// Gets or sets the plane assigned to the gate.
		/// </summary>
		internal Plane Plane
		{
			get { return _plane; }
			set { _plane = value; }
		}

		#endregion
	}
}
