using System;
using System.Collections.Generic;

namespace StudentsCalendar.Desktop.ActivitySpanViews
{
	/// <summary>
	/// Interaction logic for SpecificDatesActivitySpanView.xaml
	/// </summary>
	public partial class SpecificDatesActivitySpanView
		: BaseCalendarView
	{
		public SpecificDatesActivitySpanView()
		{
			InitializeComponent();

			base.Calendar = this.SelectedDates;
		}
	}
}
