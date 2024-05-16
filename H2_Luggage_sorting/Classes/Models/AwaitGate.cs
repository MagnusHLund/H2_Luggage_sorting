using System;
using System.Collections.Generic;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class AwaitGate
    {
        #region Fields

        private List<string> _buffer;
        private byte _head;
        private byte _tail;
        private byte _capacity;
        private byte _count;
        private uint _passengerId;
        private uint _luggageId;
        private byte _gate;

        #endregion

        #region Constructors

        public AwaitGate(byte capacity, uint passengerId, uint luggageId, byte gate)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("Capacity must be at least 1.", nameof(capacity));
            }

            _capacity = capacity;
            _buffer = new List<string>(_capacity);
            _head = 0;
            _tail = 0;
            _count = 0;
            _passengerId = passengerId;
            _luggageId = luggageId;
            _gate = gate;
        }

        #endregion

        #region Properties

        public byte Capacity
            {
                get { return _capacity; }
            }

            public byte Count
            {
                get { return _count; }
            }

            public uint PassengerId
            {
                get { return _passengerId; }
                set { _passengerId = value; }
            }

            public uint LuggageId
            {
                get { return _luggageId; }
                set { _luggageId = value; }
            }
        #endregion
    }
}