using System;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.Desktop.Dialogs
{
	/// <summary>
	/// Interaction logic for ErrorDialogView.xaml
	/// </summary>
	[Dialog(typeof(ErrorDialog))]
	public partial class ErrorDialogView
		: BaseMetroDialog, IDialogView
	{
		public ErrorDialogView()
		{
			InitializeComponent();
		}

		/// <inheritdoc />
		public Task WaitForClose()
		{
			throw new NotImplementedException();
		}
	}
}
