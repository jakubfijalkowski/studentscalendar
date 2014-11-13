using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.Desktop.Dialogs
{
	/// <summary>
	/// Interaction logic for ErrorDialogView.xaml
	/// </summary>
	[Dialog(typeof(ErrorDialog))]
	public partial class ErrorDialogView
		: BaseDialog, IDialogView
	{
		public ErrorDialogView()
		{
			InitializeComponent();
		}
	}
}
