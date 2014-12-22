using System.Windows;
using System.Windows.Controls;
using StudentsCalendar.UI.ActivitySpanViewModels;

namespace StudentsCalendar.Desktop.ActivitySpanViews
{
	/// <summary>
	/// Klasa bazowa dla widoków zawierających kalendarz, który może wybierać wiele dat.
	/// </summary>
	public class BaseCalendarView
		: UserControl
	{
		private bool PreventSelectionChange = false;
		protected Calendar Calendar;

		public BaseCalendarView()
		{
			this.DataContextChanged += this.OnDataContextChanged;
		}

		public void OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			// DataContext may be set to "parent" DataContext - it will not implement IBaseDatesSpanViewModel
			if (this.DataContext is IBaseDatesSpanViewModel && !this.PreventSelectionChange)
			{
				var vm = (IBaseDatesSpanViewModel)this.DataContext;
				vm.Dates = ((Calendar)sender).SelectedDates;
			}
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.DataContext is IBaseDatesSpanViewModel)
			{
				var vm = (IBaseDatesSpanViewModel)this.DataContext;

				this.PreventSelectionChange = true;
				this.Calendar.SelectedDates.Clear();
				foreach (var date in vm.Dates)
				{
					this.Calendar.SelectedDates.Add(date);
				}
				this.PreventSelectionChange = false;
			}
		}
	}
}
