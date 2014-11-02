using System.Collections.Generic;
using System.Linq;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Operacja sumy przedziałów.
	/// </summary>
	public sealed class WeekActivitySpanSum
		: IWeekActivitySpan
	{
		/// <summary>
		/// Pobiera listę podprzedziałów.
		/// </summary>
		public IList<IWeekActivitySpan> Spans { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public WeekActivitySpanSum()
		{
			this.Spans = new List<IWeekActivitySpan>();
		}

		/// <inheritdoc />
		public bool IsWeekActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return this.Spans.Any(s => s.IsWeekActive(baseDate, date));
		}
	}
}
