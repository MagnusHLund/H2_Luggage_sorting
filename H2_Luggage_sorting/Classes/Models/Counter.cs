using H2_Luggage_sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Luggage_sorting.Classes.Models;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class Counter : ICounter
    {
        #region Fields
        private protected List<Passenger> _buffer;
        private protected int _bufferCapacity;
        private protected string _counterId;
        private protected sbyte _status;
        #endregion

        #region Constructor
        #endregion

        #region Properties
        public string CounterId { get; }
        public sbyte Status { get; set; }
        public int BufferCapacity { get; set; }
        public List<Passenger> Buffer { get { return new List<Passenger>(_buffer);} }
        #endregion

        #region Methods
        
        

        #endregion

    }
}
