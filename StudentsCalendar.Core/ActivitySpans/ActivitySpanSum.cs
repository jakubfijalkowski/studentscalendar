using System.Collections.Generic;
using System.Linq;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Operacja sumy przedziałów.
	/// </summary>
	public sealed class ActivitySpanSum
		: IActivitySpan
	{
		/// <summary>
		/// Pobiera listę podprzedziałów.
		/// </summary>
		public IList<IActivitySpan> Spans { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public ActivitySpanSum()
		{
			this.Spans = new List<IActivitySpan>();
		}

		/// <inheritdoc />
		public bool IsActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return this.Spans.Any(s => s.IsActive(baseDate, date));
		}
	}
}
