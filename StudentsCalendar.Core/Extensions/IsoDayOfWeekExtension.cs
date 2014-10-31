using System;
using NodaTime;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Metody rozszerzające dla <see cref="IsoDyaOfWeek"/>.
	/// </summary>
	/// <remarks>
	/// Przez indeks dnia tygodnia rozumiemy wartość z przedziału 0..6, gdzie 0 odpowiada
	/// poniedziałkowi(<see cref="IsoDayOfWeek.Monday"/>), a 6 niedzieli(<see cref="IsoDayOfWeek.Sunday"/>).
	/// </remarks>
	public static class IsoDayOfWeekExtension
	{
		/// <summary>
		/// Konwertuje <see cref="IsoDayOfWeek"/> na odpowiedni indeks.
		/// </summary>
		/// <param name="day">Dzień tygodnia do skonwertowania.</param>
		/// <returns>Indeks odpowiadający parametrowi.</returns>
		public static int ToIndex(this IsoDayOfWeek day)
		{
			if (day == IsoDayOfWeek.None)
			{
				throw new ArgumentOutOfRangeException("Cannot convert value None to index.");
			}
			return (int)day - 1;
		}

		/// <summary>
		/// Konwertuje indeks na <see cref="IsoDayOfWeek"/>.
		/// </summary>
		/// <param name="index">Indeks, uzyskany przez wywołanie <see cref="ToIndex"/>.</param>
		/// <returns>Dzień tygodnia odpowiadający danemu indeksowi.</returns>
		public static IsoDayOfWeek ToDayOfWeek(this int index)
		{
			if (index < 0 || index > 6)
			{
				throw new ArgumentOutOfRangeException("index", "Index value must be in range 0..6 to be correct IsoDayOfWeek.");
			}
			return (IsoDayOfWeek)(index + 1);
		}
	}
}
