using System;
using System.Windows.Data;
using NodaTime;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje <see cref="LocalDate"/> na <see cref="DateTime"/> i na odwrót.
	/// </summary>
	public sealed class NodaToBclConverter
		: IValueConverter
	{
		/// <inheritdocs />
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value is LocalDate)
			{
				var date = (LocalDate)value;
				return new DateTime(date.Year, date.Month, date.Day);
			}
			else if (value is LocalTime)
			{
				var time = (LocalTime)value;
				return new DateTime(2000, 1, 1, time.Hour, time.Minute, time.Second);
			}
			else
			{
				var date = (DateTime)value;
				if (targetType == typeof(LocalDate))
				{
					return new LocalDate(date.Year, date.Month, date.Day);
				}
				else
				{
					return new LocalTime(date.Hour, date.Minute, date.Second);
				}
			}
		}

		/// <inheritdocs />
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return this.Convert(value, targetType, parameter, culture);
		}
	}
}
