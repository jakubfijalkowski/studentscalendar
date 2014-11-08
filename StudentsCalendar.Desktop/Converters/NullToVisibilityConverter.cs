using System;
using System.Windows;
using System.Windows.Data;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje <c>null</c> na <see cref="Visibility.Collapsed"/> i nie-<c>null</c> na <see cref="Visibility.Visible"/>.
	/// </summary>
	public sealed class NullToVisibilityConverter
		: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return value == null ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
