using System;
using System.Windows;
using System.Windows.Data;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje początkowy slot na margines górny.
	/// </summary>
	sealed class SlotToMarginConverter
		: IValueConverter
	{
		/// <summary>
		/// Pobiera lub zmienia wysokość pojedynczego slotu.
		/// </summary>
		public double SlotHeight { get; set; }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var classes = (ArrangedClasses)value;
			return new Thickness(0, classes.StartSlot * this.SlotHeight, 0, 0);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
