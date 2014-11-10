using System;
using System.Windows.Data;
using NodaTime;

namespace StudentsCalendar.Desktop.Converters
{
	/// <summary>
	/// Konwertuje "odległość" w tygodniach od aktualnego tygodnia
	/// i konwertuje otrzymany wynik na ciąg znaków.
	/// </summary>
	/// <remarks>
	/// Konwerer przyjmuje dwie wartości - datę bazową i datę aktualną.
	/// 
	/// Wynikiem konwersji jest np. "aktualny", "poprzedni", "+4".
	/// </remarks>
	sealed class WeekOffsetToStringConverter
		: IMultiValueConverter
	{
		/// <inheritdoc />
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			var baseDate = (LocalDate)values[0];
			var date = (LocalDate)values[1];

			var diff = Period.Between(baseDate, date, PeriodUnits.Weeks).Weeks;

			//TODO: move to resources
			switch (diff)
			{
				case 0:
					return "aktualny";
				case 1:
					return "następny";
				case -1:
					return "poprzedni";
				default:
					return Math.Abs(diff) + " tyg. " + ((diff < 0) ? "wstecz" : "naprzód");
			}
		}

		/// <inheritdoc />
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
