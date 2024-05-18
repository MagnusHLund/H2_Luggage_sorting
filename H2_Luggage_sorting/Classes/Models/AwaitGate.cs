using System;
using System.Collections.Generic;
using System.Threading;

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
        private bool _checkIfGateIsOpen;

        #endregion

        #region Constructors

        public AwaitGate(byte capacity, uint passengerId, uint luggageId, byte gate)
        {
            _capacity = capacity;
            _passengerId = passengerId;
            _luggageId = luggageId;
            _gate = gate;
            _buffer = new List<string>(capacity);
            _head = 0;
            _tail = 0;
            _count = 0;
            _checkIfGateIsOpen = false;
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

        public bool CheckIfGateIsOpen
        {
            get { return _checkIfGateIsOpen; }
            set { _checkIfGateIsOpen = value; }
        }

        #endregion

        #region Methods

        public static void StartMonitoring()
        {
            Thread gateMonitoringThread = new Thread(new ThreadStart(MonitorGateStatus));
            gateMonitoringThread.Start();
        }

        private static void MonitorGateStatus()
        {
            while (true)
            {
                for (int gateNumber = 1; gateNumber <= 3; gateNumber++)
                {
                    bool isGateOpen = CheckIfGateIsOpenMethod(gateNumber);

                    if (isGateOpen)
                    {
                        // Move customers to gate
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private static bool CheckIfGateIsOpenMethod(int gateNumber)
        {
            // Implement gate status check logic here
            return false;
        }

        #endregion
    }
}