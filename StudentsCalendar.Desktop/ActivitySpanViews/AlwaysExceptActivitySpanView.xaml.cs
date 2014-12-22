using System;
using System.Collections.Generic;

namespace StudentsCalendar.Desktop.ActivitySpanViews
{
	/// <summary>
	/// Interaction logic for AlwaysExceptActivitySpanView.xaml
	/// </summary>
	public partial class AlwaysExceptActivitySpanView
		: BaseCalendarView
	{
		public AlwaysExceptActivitySpanView()
		{
			InitializeComponent();

			base.Calendar = this.SelectedDates;
		}
	}
}
