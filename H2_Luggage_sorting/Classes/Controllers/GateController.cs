using H2_Luggage_sorting.Classes.Models;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace H2_Luggage_sorting.Classes.Controllers
{
	internal class GateController
	{
		#region Instances
		private TimeModel _timeModel;
		private GateModel _gateModel;
		private TimeController _timeController;
		private readonly object _lock = new object(); // Lock object
		#endregion

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the GateController class with the provided time and gate models.
		/// </summary>
		/// <param name="timeModel">The time model.</param>
		/// <param name="gateModel">The gate model.</param>
		internal GateController(TimeModel timeModel, GateModel gateModel)
		{
			this._timeModel = timeModel;
			this._gateModel = gateModel;
			this._timeController = new TimeController(_timeModel, null, null);
		}
		#endregion

		#region Methods
		/// <summary>
		/// Handles the click event for a gate, either opening or closing it based on its current state.
		/// </summary>
		/// <param name="gate">The gate to handle.</param>
		internal void HandleGateClick(Gate gate)
		{
			lock (_lock) // Ensure that gate operations are thread-safe
			{
				if (gate.IsGateOpen)
				{
					CloseGate(gate);
				}
				else
				{
					OpenGate(gate);
				}
			}
		}

		/// <summary>
		/// Opens the specified gate if it meets the necessary conditions.
		/// </summary>
		/// <param name="gate">The gate to open.</param>
		internal void OpenGate(Gate gate)
		{
			lock (_lock) // Ensure that opening the gate is thread-safe
			{
				if (gate.Plane != null && !_gateModel.Gates.Any(g => g.IsGateOpen && g.Plane == gate.Plane))
				{
					gate.IsGateOpen = true;
					Console.WriteLine($"Gate {gate.GateNumber} is now open for flight {gate.Plane.FlightNumber}.");
				}
			}
		}

		/// <summary>
		/// Closes the specified gate.
		/// </summary>
		/// <param name="gate">The gate to close.</param>
		internal void CloseGate(Gate gate)
		{
			lock (_lock) // Ensure that closing the gate is thread-safe
			{
				gate.IsGateOpen = false;
				Console.WriteLine($"Gate {gate.GateNumber} is now closed. Flight {gate.Plane.FlightNumber} has departed.");
				_gateModel.Gates.Remove(gate);
			}
		}

		/// <summary>
		/// Updates the status of gates, opening them if departure time is near.
		/// </summary>
		internal void UpdateGateStatus()
		{
			lock (_lock) // Ensure that updating gate status is thread-safe
			{
				DateTime currentTime = _timeModel.Date;
				foreach (var gate in _gateModel.Gates)
				{
					if (!gate.IsGateOpen && gate.Plane.DepartureTime.AddHours(Gate.GATE_OPENING_TIME_BEFORE_DEPARTURE) <= currentTime)
					{
						OpenGate(gate);
					}
				}
			}
		}
		#endregion
	}
}