using H2_Luggage_sorting.Classes.Controllers;
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

namespace H2_Luggage_sorting
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent(); 
			startupThreads();
		}

		private void startupThreads()
		{
			// Starts threads for al the processes
			//ThreadPool.QueueUserWorkItem(new TimeController().AddMinuteToDate(1));
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