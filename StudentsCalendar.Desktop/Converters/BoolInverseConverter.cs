using System;
using System.Windows.Data;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje wartość boolowską na przeciwną.
	/// </summary>
	sealed class BoolInverseConverter
		: IValueConverter
	{
		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return !(bool)value;
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
