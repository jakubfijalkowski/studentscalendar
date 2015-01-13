using System;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.Desktop.Dialogs
{
	/// <summary>
	/// Bazowa klasa dialogów która poprawia <see cref="BaseMetroDialog"/> i implementuje
	/// <see cref="IDialogView"/>.
	/// </summary>
	public abstract class BaseDialog
		: BaseMetroDialog, IDialogView
	{
		protected readonly TaskCompletionSource<object> CloseSource = new TaskCompletionSource<object>();

		public BaseDialog()
		{
			this.DataContextChanged += this.OnDataContextChanged;
		}

		/// <inheritdoc />
		public Task WaitForClose()
		{
			return this.CloseSource.Task;
		}

		/// <summary>
		/// "Event handler" ustawiający <see cref="CloseSource"/> na zakończone.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void CloseDialog(object sender, EventArgs e)
		{
			this.CloseSource.SetResult(null);
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.Content is FrameworkElement)
			{
				((FrameworkElement)this.Content).DataContext = e.NewValue;
			}
		}
	}
}
