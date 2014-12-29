using System.Windows.Controls;
using NodaTime;

namespace StudentsCalendar.Desktop.ModifierViews
{
	/// <summary>
	/// Interaction logic for ChangeWeekdayView.xaml
	/// </summary>
	public partial class ChangeWeekdayView
		: UserControl
	{
		private readonly EnumDesc[] AvailableDays = new[]
		{
			new EnumDesc { Label = "poniedziałek", Value = IsoDayOfWeek.Monday },
			new EnumDesc { Label = "wtorek", Value = IsoDayOfWeek.Tuesday },
			new EnumDesc { Label = "środę", Value = IsoDayOfWeek.Wednesday },
			new EnumDesc { Label = "czwartek", Value = IsoDayOfWeek.Thursday },
			new EnumDesc { Label = "piątek", Value = IsoDayOfWeek.Friday },
			new EnumDesc { Label = "sobotę", Value = IsoDayOfWeek.Saturday },
			new EnumDesc { Label = "niedzielę", Value = IsoDayOfWeek.Sunday }
		};

		public ChangeWeekdayView()
		{
			InitializeComponent();

			this.DayOfWeekComboBox.ItemsSource = this.AvailableDays;
		}

		private sealed class EnumDesc
		{
			public string Label { get; set; }

			public IsoDayOfWeek Value { get; set; }
		}
	}
}
