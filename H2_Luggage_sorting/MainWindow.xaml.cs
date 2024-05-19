﻿using H2_Luggage_sorting.Classes.Controllers;
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
		private TimeModel _timeModel = new TimeModel(6, 1, 2024, 100);
		private PassengersModel _passengersModel = new PassengersModel();
		private CountersModel _countersModel = new CountersModel();
		private GateModel _gateModel = new GateModel();
		private LuggageModel _luggageModel = new LuggageModel();
		private PlaneModel _planeModel = new PlaneModel();

		public MainWindow()
		{
			InitializeComponent(); 
			startupThreads();
		}

		private void startupThreads()
		{
			// Time
			const int ticks = 100;
			TimeController timeController = new TimeController(_timeModel, Dispatcher.CurrentDispatcher, clock);
			Thread thread = new Thread(() => timeController.AddMinutesToDate(1));
			thread.Start();

			// Check-in
			CheckInController checkInController = new CheckInController(_timeModel, _passengersModel, _countersModel, _luggageModel, Dispatcher);
			Task.Run(() => checkInController.HandleCounters());

			// Luggage controller
			LuggageController luggageController = new LuggageController(_luggageModel);
			Task.Run(() => luggageController.SortLuggageToGate());

			// Status report
			StatusReportController statusReportController = new StatusReportController(_planeModel, _timeModel, _luggageModel);
			Task.Run(() => statusReportController.GenerateStatusReport());

			new PlaneController(_planeModel, _timeModel).GetFlights();
		}

		private void NavbarButton_Click(object sender, RoutedEventArgs e)
		{
			Button button = sender as Button;
			if (button != null)
			{
				string sectionName = button.Tag.ToString();
				ShowSection(sectionName);
			}
		}

		private void ShowSection(string sectionName)
		{
			CheckInSection.Visibility = sectionName == "CheckInSection" ? Visibility.Visible : Visibility.Collapsed;
			ConveyorBeltSection.Visibility = sectionName == "ConveyorBeltSection" ? Visibility.Visible : Visibility.Collapsed;
			GatesSection.Visibility = sectionName == "GatesSection" ? Visibility.Visible : Visibility.Collapsed;
		}

	}
}