using System;
using System.Windows.Data;
using NodaTime;
using NodaTime.Text;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje <see cref="LocalDate"/> lub <see cref="LocalDateTime"/> na dzień
	/// tekstową reprezentacje dnia tygodnia, uwzględniając ustawienia języka.
	/// </summary>
	sealed class DateToDayOfWeekConverter
		: IValueConverter
	{
		private readonly LocalDatePattern Pattern = LocalDatePattern.CreateWithCurrentCulture("dddd");

		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return this.Pattern.Format(value is LocalDateTime ? ((LocalDateTime)value).Date : (LocalDate)value);
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
