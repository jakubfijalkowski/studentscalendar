using Caliburn.Micro;
using MahApps.Metro.Controls;
using StudentsCalendar.UI.Events;
using StudentsCalendar.UI.Main;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		private readonly IEventAggregator EventAggregator;

		public MainWindow(IEventAggregator eventAggregator)
		{
			InitializeComponent();

			this.EventAggregator = eventAggregator;
		}

		private void WeekView_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.EventAggregator.PublishOnCurrentThread(NavigateRequestEvent.Create<CurrentWeekViewModel>());
		}

		private void MonthView_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.EventAggregator.PublishOnCurrentThread(NavigateRequestEvent.Create<MonthViewModel>());
		}
	}
}
