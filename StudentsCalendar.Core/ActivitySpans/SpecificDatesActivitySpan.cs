using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który jest aktywny tylko w określone daty.
	/// </summary>
	public sealed class SpecificDatesActivitySpan
		: IDailyActivitySpan
	{
		/// <summary>
		/// Pobiera lub zmienia listę dat, w które przedział jest aktywny.
		/// </summary>
		public IList<LocalDate> Dates { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public SpecificDatesActivitySpan()
		{
			this.Dates = new List<LocalDate>();
		}

		/// <inheritdoc />
		public bool IsActive(LocalDate baseDate, LocalDate date)
		{
			return this.Dates.Contains(date);
		}
	}
}
