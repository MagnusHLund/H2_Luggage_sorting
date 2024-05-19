using H2_Luggage_sorting.Classes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace H2_Luggage_sorting.Classes.Controllers
{
    internal class GateController
    {


        private TimeModel _timeModel;
        private PassengersModel _passengersModel;
        private CountersModel _countersModel;
        private LuggageModel _luggageModel;
        private TimeController _timeController;

        internal GateController(TimeModel timeModel, PassengersModel passengersModel, CountersModel countersModel, LuggageModel luggageModel, Dispatcher dispatch)
        {
            this._timeModel = timeModel;
            this._passengersModel = passengersModel;
            this._countersModel = countersModel;
            this._luggageModel = luggageModel;

            _timeController = new TimeController(_timeModel, null, null);
        }

        #region Methods
        // Denne metode tage alle fly afgangene for en dag, den tager 3 fly afgange ad gangen, når den har taget 3, 
        internal void OpenCloseGate(List<Gate> gates, List<Plane> planes) // TODO: Fix List<Gate> to GateModel and same with planes
		{
            // Counting how many gates currently are used
            byte count = 0;
            while (true)
            {
                for (byte i = 0; i < planes.Count(); i++)                // TODO: hvis mindre end 3 afgange er tilbage vil den køre forevigt.
                {
                    if (count >= 3)                                     // maybe add or statement here?
                    {
                        // Waiting for all depatures
                        WaitForAllDepatures(gates);
                        count = 0;

                                                                          // TODO: remove airplane from gate list in gatemodel when airplane has left.
                    }
                    else
                    {
                        // Adding airplane to current gates used
                        Gate gateTemp = new Gate(count, false, planes[i]);
                        gates.Add(gateTemp);
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// This method takes a list of gates, the gates that are currently in use.
        /// </summary>
        /// <param name="gates"></param>
        internal void WaitForAllDepatures(List<Gate> gates)
        {
            _timeController = new TimeController(_timeModel, null, null);

            // going through the 3 gates in a foreach loop
            foreach (Gate gate in gates)
            {
                // Getting current time og departure time
                DateTime currentTime = _timeModel.GetDateTime();
                DateTime departureTime = gate.Plane.DepartureTime;
                // Starting a new thread for each gate
                Thread thread = new Thread(() => WaitForDepature(departureTime, currentTime));

            }
        }

        /// <summary>
        /// This method takes two datetime variables and waits until they "match" each other
        /// </summary>
        /// <param name="depature"></param>
        /// <param name="currentime"></param>
        internal void WaitForDepature(DateTime depature, DateTime currentime)
        {
            while (currentime < depature)
            {
                Thread.Sleep(_timeModel.GetTicks());
            }
        }
        #endregion
    }
}