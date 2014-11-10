using System;
using System.Windows;
using System.Windows.Data;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje wartość boolowską na <see cref="Visibility"/>.
	/// </summary>
	public sealed class BoolToVisibilityConverter
		: IValueConverter
	{
		/// <summary>
		/// Wskazuje, czy operacja konwersji ma być odwrotna, tj.
		/// <c>true</c> -> <see cref="Visibility.Collapsed"/> a <c>false</c> -> <see cref="Visibility.Visible"/>.
		/// </summary>
		public bool Reverse { get; set; }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return (bool)value ^ this.Reverse ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
