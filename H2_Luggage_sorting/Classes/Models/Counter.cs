using H2_Luggage_sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Luggage_sorting.Classes.Models;
using System.Collections.Concurrent;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class Counter : ICounter
    {
        #region Fields
        private protected byte _maxQueueLength;
        private protected BlockingCollection<Passenger> _buffer;
        private protected byte _status;
        #endregion

        #region Properties
        public sbyte Status { get; set; }

        #endregion

        internal Counter (byte status = 0, byte maxQueueLength = 10)
        {
            _status = status;
            _maxQueueLength = maxQueueLength;
            _buffer = new BlockingCollection<Passenger>(_maxQueueLength);
        }

        #region Methods

        internal int GetCounterQueueLength()
        {
            return _buffer.Count;
        }

        internal void RemovePassengerFromQueue()
        {
			_buffer.TryTake(out Passenger passenger);
		}

        internal void AddPassengerToQueue(Passenger passenger)
        {
            _buffer.Add(passenger);
        }

        internal byte GetMaxQueueCapacitiy()
        {
            return _maxQueueLength;
        }

        internal Passenger GetFirstPassengerInQueue()
        {
            return _buffer.First();
        }
        #endregion

    }
}