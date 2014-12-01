using System.Collections.Generic;
using System.Linq;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Operacja sumy przedziałów.
	/// </summary>
	public sealed class WeekActivitySpanSum
		: IWeeklyActivitySpan
	{
		/// <summary>
		/// Pobiera listę podprzedziałów.
		/// </summary>
		public IList<IWeeklyActivitySpan> Spans { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public WeekActivitySpanSum()
		{
			this.Spans = new List<IWeeklyActivitySpan>();
		}

		/// <inheritdoc />
		public bool IsWeekActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return this.Spans.Any(s => s.IsWeekActive(baseDate, date));
		}
	}
}
