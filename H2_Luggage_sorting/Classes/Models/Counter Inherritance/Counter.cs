using H2_Luggage_sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Luggage_sorting.Classes.Models
{
    internal abstract class Counter : ICounter
    {
        #region Fields
        private protected string _counterId;
        private protected sbyte _status;
        #endregion

        #region Constructor
        #endregion

        #region Properties
        public string CounterId { get; }
        public sbyte Status { get; set; }
        #endregion

    }
}
