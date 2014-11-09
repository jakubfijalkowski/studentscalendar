using System;
using System.Windows.Data;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje zajmowane sloty do wysokości.
	/// </summary>
	sealed class SlotToHeightConverter
		: IValueConverter
	{
		/// <summary>
		/// Pobiera lub zmienia wysokość slotu.
		/// </summary>
		public double SlotHeight { get; set; }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var classes = (ArrangedClasses)value;
			return (classes.EndSlot - classes.StartSlot) * this.SlotHeight;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
