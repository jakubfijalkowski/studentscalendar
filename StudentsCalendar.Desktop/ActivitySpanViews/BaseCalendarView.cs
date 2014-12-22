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

		private bool IsViewModelCorrect
		{
			// DataContext may be set to "parent" DataContext - it will not implement IBaseDatesSpanViewModel
			get { return this.DataContext is IBaseDatesSpanViewModel; }
		}

		private IBaseDatesSpanViewModel ViewModel
		{
			get { return (IBaseDatesSpanViewModel)this.DataContext; }
		}

		public BaseCalendarView()
		{
			this.DataContextChanged += this.OnDataContextChanged;
		}

		public void OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.IsViewModelCorrect && !this.PreventSelectionChange)
			{
				this.PreventSelectionChange = true;
				if (this.ViewModel.UpdateDates(this.Calendar.SelectedDates))
				{
					this.UpdateDates();
				}
				this.PreventSelectionChange = false;
			}
		}

		private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (this.IsViewModelCorrect)
			{
				this.PreventSelectionChange = true;
				this.UpdateDates();
				this.PreventSelectionChange = false;
			}
		}

		private void UpdateDates()
		{
			this.Calendar.SelectedDates.Clear();
			foreach (var date in this.ViewModel.Dates)
			{
				this.Calendar.SelectedDates.Add(date);
			}
		}
	}
}
