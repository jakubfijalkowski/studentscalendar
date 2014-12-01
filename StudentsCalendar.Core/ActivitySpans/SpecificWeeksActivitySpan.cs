using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który jest aktywny tylko w określone daty.
	/// </summary>
	public sealed class SpecificWeeksActivitySpan
		: IDailyActivitySpan, IWeeklyActivitySpan
	{
		/// <summary>
		/// Pobiera lub zmienia listę dat(poniedziałki), w które przedział jest aktywny.
		/// </summary>
		public IList<LocalDate> Dates { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public SpecificWeeksActivitySpan()
		{
			this.Dates = new List<LocalDate>();
		}

		/// <inheritdoc />
		public bool IsActive(LocalDate baseDate, LocalDate date)
		{
			if(date.IsoDayOfWeek != IsoDayOfWeek.Monday)
			{
				date = date.Previous(IsoDayOfWeek.Monday);
			}
			return this.IsWeekActive(baseDate, date);
		}

		/// <inheritdoc />
		public bool IsWeekActive(LocalDate baseDate, LocalDate date)
		{
			return this.Dates.Contains(date);
		}

	}
}
