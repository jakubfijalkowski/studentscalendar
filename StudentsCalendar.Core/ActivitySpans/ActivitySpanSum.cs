using System.Collections.Generic;
using System.Linq;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Operacja sumy przedziałów.
	/// </summary>
	public sealed class ActivitySpanSum
		: IDailyActivitySpan
	{
		/// <summary>
		/// Pobiera listę podprzedziałów.
		/// </summary>
		public IList<IDailyActivitySpan> Spans { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public ActivitySpanSum()
		{
			this.Spans = new List<IDailyActivitySpan>();
		}

		/// <inheritdoc />
		public bool IsActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return this.Spans.Any(s => s.IsActive(baseDate, date));
		}
	}
}
