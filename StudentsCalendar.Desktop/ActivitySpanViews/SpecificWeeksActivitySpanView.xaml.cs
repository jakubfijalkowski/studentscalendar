using System;
using System.Collections.Generic;

namespace StudentsCalendar.Desktop.ActivitySpanViews
{
	/// <summary>
	/// Interaction logic for SpecificWeeksActivitySpanView.xaml
	/// </summary>
	public partial class SpecificWeeksActivitySpanView
		: BaseCalendarView
	{
		public SpecificWeeksActivitySpanView()
		{
			InitializeComponent();

			base.Calendar = this.SelectedDates;
		}
	}
}
