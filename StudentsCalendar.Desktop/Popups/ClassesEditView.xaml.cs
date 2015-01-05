using System.Windows;
using System.Windows.Controls;

namespace StudentsCalendar.Desktop.Popups
{
	/// <summary>
	/// Interaction logic for ClassesEditView.xaml
	/// </summary>
	public partial class ClassesEditView : UserControl
	{
		private int ErrorsCount = 0;

		public ClassesEditView()
		{
			InitializeComponent();

			// Lekki hak, ale tego się nie da normalnie w WPF'ie zrobić...
			Validation.AddErrorHandler(this.ShortName, this.OnDataError);
			Validation.AddErrorHandler(this.FullName, this.OnDataError);
		}

		private void OnDataError(object sender, ValidationErrorEventArgs args)
		{
			this.ErrorsCount += args.Action == ValidationErrorEventAction.Added ? 1 : -1;
			this.Save.IsEnabled = this.ErrorsCount == 0;
		}
	}
}
