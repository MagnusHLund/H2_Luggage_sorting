using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    /// <summary>
    /// This class is responsible for handling gates, their opening times, and if they're open.
    /// </summary>
    internal class Gate
    {
        // This const is responisble for the amount of hours before a gate opens before depature time.
        const int GATE_OPENING_TIME_BEFORE_DEPATURE = -1;
        #region Fields

        private byte _gateNumber;
        private bool _isGateOpen;
        private Plane _plane;
        private DateTime _gateOpeningTime;

        /// <summary>
        /// Gate opening time is calculated in the constructor.
        /// </summary>

        #endregion

        #region Constructors

        public Gate(byte gateNumber, bool isGateOpen, Plane plane)
        {
            _gateNumber = gateNumber;
            _isGateOpen = isGateOpen;
            _plane = plane;
            // Removing one our from our depatureTime variable, and storing it in our _gateOpeningTime variable, because gates open 1 hour before departure time.
            DateTime depatureTime = plane.DepartureTime.AddHours(GATE_OPENING_TIME_BEFORE_DEPATURE);
            _gateOpeningTime = depatureTime;
        }

        #endregion

        #region Properties

        public byte GateNumber
        {
            get { return _gateNumber; }
            set { _gateNumber = value; }
        }

        public bool IsGateOpen
        {
            get { return _isGateOpen; }
            set { _isGateOpen = value; }
        }

        public Plane Plane
        {
            get { return _plane; }
            set { this._plane = value; }
        }
        #endregion
    }
}