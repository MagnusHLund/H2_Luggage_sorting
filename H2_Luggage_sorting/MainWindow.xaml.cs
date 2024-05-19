using H2_Luggage_sorting.Classes.Controllers;
using H2_Luggage_sorting.Classes.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace H2_Luggage_sorting
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private TimeModel _timeModel = new TimeModel(6, 1, 2024);
		private PassengersModel _passengersModel = new PassengersModel();
		private CountersModel _countersModel = new CountersModel();

		public MainWindow()
		{
			InitializeComponent(); 
			startupThreads();
		}

		private void startupThreads()
		{
			// Time
			const int ticks = 100;
			TimeController timeController = new TimeController(_timeModel, ticks, Dispatcher.CurrentDispatcher, clock);
			Thread thread = new Thread(() => timeController.AddMinutesToDate(1));
			thread.Start();

			// Check-in
			// ^ New passengers gets created, at midnight everyday, based on the flight that they have to be on.
			// ^ This information is gathered from a stored procedure.
			// ^ There are 3 check-in counters and each can help 1 passenger at a time. It takes 1 minute to help a passenger. 
			// ^ There is minimum 1 counter open and number 2 opens if number 1 has 20 people in queue. Number 3 opens if number 2 has 20 people in queue. 
			CheckInController checkInController = new CheckInController(_timeModel, _passengersModel, _countersModel);
			ThreadPool.QueueUserWorkItem(checkInController.HandleCounters());

			// 

		}

		private void Navbar()
		{
			// Changes which view is displayed
		}

		private void MyButton_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}