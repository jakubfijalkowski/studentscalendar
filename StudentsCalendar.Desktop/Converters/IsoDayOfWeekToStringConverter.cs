using System;
using System.Windows.Data;
using NodaTime;
using NodaTime.Text;
using StudentsCalendar.Core;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje <see cref="IsoDayOfWeek"/> na odpowiadający ciąg znaków.
	/// </summary>
	/// <remarks>
	/// Domyślnie używa "CurrentCulture", więc nie trzeba używać tego konwertera w połączeniu z
	/// <see cref="Helpers.BindingWithCurrentCulture"/>.
	/// </remarks>
	sealed class IsoDayOfWeekToStringConverter
		: IValueConverter
	{
		private readonly LocalDatePattern Pattern = LocalDatePattern.CreateWithCurrentCulture("dddd");

		/// <inheritdoc />
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return this.Pattern.Format(DateHelper.Today.Next((IsoDayOfWeek)value));
		}

		/// <inheritdoc />
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
