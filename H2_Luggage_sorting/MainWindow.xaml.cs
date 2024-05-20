using H2_Luggage_sorting.Classes.Controllers;
using H2_Luggage_sorting.Classes.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace H2_Luggage_sorting
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Models and controllers
		private TimeModel _timeModel = new TimeModel(6, 1, 2024, 100);
		private PassengersModel _passengersModel = new PassengersModel();
		private CountersModel _countersModel = new CountersModel(new List<Counter>
		{
			new Counter(new Image(), "Available"),
			new Counter(new Image(), "Available"),
			new Counter(new Image(), "Available")
		});
		private GateModel _gateModel = new GateModel();
		private LuggageModel _luggageModel = new LuggageModel();
		private PlaneModel _planeModel = new PlaneModel();

		public MainWindow()
		{
			InitializeComponent();
			startupThreads(); // Start background threads
		}

		// Method to start background threads for various controllers
		private void startupThreads()
		{
			// Time controller
			TimeController timeController = new TimeController(_timeModel, Dispatcher.CurrentDispatcher, clock);
			Task.Run(() => timeController.AddMinutesToDate(1));

			// Check-in controller
			CheckInController checkInController = new CheckInController(_timeModel, _passengersModel, _countersModel, _luggageModel, Dispatcher);
			Task.Run(() => checkInController.HandleCounters());

			// Luggage controller
			LuggageController luggageController = new LuggageController(_luggageModel);
			Task.Run(() => luggageController.SortLuggageToGate());

			// Status report controller
			StatusReportController statusReportController = new StatusReportController(_planeModel, _timeModel, _luggageModel);
			Task.Run(() => statusReportController.GenerateStatusReport());

			// Plane controller
			new PlaneController(_planeModel, _timeModel).GetFlights();
		}

		// Event handler for navbar button clicks
		private void NavbarButton_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				string sectionName = button.Tag.ToString();
				ShowSection(sectionName); // Show the corresponding section
			}
		}

		// Method to show or hide sections based on the selected navbar button
		private void ShowSection(string sectionName)
		{
			CheckInSection.Visibility = sectionName == "CheckInSection" ? Visibility.Visible : Visibility.Collapsed;
			ConveyorBeltSection.Visibility = sectionName == "ConveyorBeltSection" ? Visibility.Visible : Visibility.Collapsed;
			GatesSection.Visibility = sectionName == "GatesSection" ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
