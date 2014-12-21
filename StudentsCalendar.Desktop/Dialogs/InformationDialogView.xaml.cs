using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.Desktop.Dialogs
{
	/// <summary>
	/// Interaction logic for InformationDialogView.xaml
	/// </summary>
	[Dialog(typeof(InformationDialog))]
	public partial class InformationDialogView
		: BaseDialog, IDialogView
	{
		public InformationDialogView()
		{
			InitializeComponent();
		}
	}
}
