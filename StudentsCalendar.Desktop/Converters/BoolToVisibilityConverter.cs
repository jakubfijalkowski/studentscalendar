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
		public bool Inverse { get; set; }

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			bool inverse = this.Inverse || ParameterToBool(parameter);
			return (bool)value ^ inverse ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		private static bool ParameterToBool(object parameter)
		{
			if (parameter != null)
			{
				if (parameter is string)
				{
					string val = (string)parameter;
					return val == "1" || val.ToLower() == "true";
				}
				if (parameter is bool)
				{
					return (bool)parameter;
				}
				if (parameter is int)
				{
					return (int)parameter != 0;
				}
			}
			return false;
		}
	}
}
