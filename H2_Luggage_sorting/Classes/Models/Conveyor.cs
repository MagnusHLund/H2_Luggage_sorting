using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class Conveyor
	{
        #region Fields

        private protected string[] _buffer;
        private protected byte _head;
        private protected byte _tail;
        private protected byte _capacity;
        private protected byte _count;
        private protected string _passangerId;
        private protected string _luggageId;
        private protected byte _gate;

        #endregion

        #region Constructors
        

        #endregion

        #region Properties

        #endregion 

        #region Methods
        public void ConveyorBelt(byte capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentException("");
            }
        }
        #endregion
    }
}
