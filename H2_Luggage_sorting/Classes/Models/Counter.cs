using System.Collections.Concurrent;
using System.Windows.Controls;

namespace H2_Luggage_sorting.Classes.Models
{
    internal class Counter
    {
        #region Fields
        private protected byte _maxQueueLength;
        private protected BlockingCollection<Passenger> _buffer;
        private protected string _status;
        private protected Image _image;
        #endregion

        #region Properties
        internal byte MaxQueueLength { get;  }
        internal BlockingCollection<Passenger> Buffer { get; set; }
        internal string Status { get; set; }


		#endregion

		internal Counter (Image image, string status = "Available", byte maxQueueLength = 10)
        {
            _status = status;
            _maxQueueLength = maxQueueLength;
            _buffer = new BlockingCollection<Passenger>(_maxQueueLength);
            _image = image;
        }
    }
}