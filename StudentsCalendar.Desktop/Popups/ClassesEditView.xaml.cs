using System.Windows;
using System.Windows.Controls;

namespace StudentsCalendar.Desktop.Popups
{
	/// <summary>
	/// Interaction logic for ClassesEditView.xaml
	/// </summary>
	public partial class ClassesEditView : UserControl
	{
		public ClassesEditView()
		{
			InitializeComponent();
		}

		private void OpenContextMenu(object sender, RoutedEventArgs e)
		{
			var cm = ((Button)sender).ContextMenu;
			cm.PlacementTarget = (Button)sender;
			cm.IsOpen = !cm.IsOpen;
		}
	}
}
