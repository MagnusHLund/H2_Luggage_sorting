using System.Collections.Concurrent;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace H2_Luggage_sorting.Classes.Models
{
	internal class Counter : INotifyPropertyChanged
	{
		private byte _maxQueueLength;
		private BlockingCollection<Passenger> _buffer;
		private string _status;
		private ImageSource _imageSource;

		// Property to get the maximum queue length
		public byte MaxQueueLength
		{
			get { return _maxQueueLength; }
		}

		// Property to get or set the buffer of passengers
		public BlockingCollection<Passenger> Buffer
		{
			get { return _buffer; }
			set
			{
				_buffer = value;
				OnPropertyChanged(nameof(Buffer));
			}
		}

		// Property to get or set the status of the counter
		public string Status
		{
			get { return _status; }
			set
			{
				_status = value;
				OnPropertyChanged(nameof(Status));
			}
		}

		// Property to get or set the image source of the counter
		public ImageSource ImageSource
		{
			get { return _imageSource; }
			set
			{
				_imageSource = value;
				OnPropertyChanged(nameof(ImageSource));
			}
		}

		// Constructor to initialize a counter with an image, status, and maximum queue length
		public Counter(Image image, string status = "Available", byte maxQueueLength = 10)
		{
			_status = status;
			_maxQueueLength = maxQueueLength;
			_buffer = new BlockingCollection<Passenger>(_maxQueueLength);
			_imageSource = image.Source;
		}

		// Event to notify property changes
		public event PropertyChangedEventHandler PropertyChanged;

		// Method to invoke property changed event
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
