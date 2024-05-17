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
    internal class GateModel
    {
        // This const is responisble for the amount of hours before a gate opens before depature time.
        const int GATE_OPENING_TIME_BEFORE_DEPATURE = 1;
        #region Fields

        private protected byte _gateNumber;
        private protected bool _isGateOpen;
        /// <summary>
        /// Gate opening time is calculated in the constructor.
        /// </summary>
        private protected DateTime _gateOpeningTime;

        #endregion

        #region Constructors

        public GateModel(byte gateNumber, bool isGateOpen, DateTime depatureTime) 
        {
            _gateNumber = gateNumber;
            _isGateOpen = isGateOpen;
            // Removing one our from our depatureTime variable, and storing it in our _gateOpeningTime variable, because gates open 1 hour before departure time.
            depatureTime.AddHours(GATE_OPENING_TIME_BEFORE_DEPATURE);
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

        public DateTime GateOpeningTime
        {
            get { return _gateOpeningTime; }
            set { this._gateOpeningTime = value; }
        }
        #endregion
    }
}
