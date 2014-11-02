using System.Collections.Generic;
using System.Linq;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Operacja iloczynu przedziałów.
	/// </summary>
	public sealed class ActivitySpanProduct
		: IActivitySpan
	{
		/// <summary>
		/// Pobiera listę podprzedziałów.
		/// </summary>
		public IList<IActivitySpan> Spans { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt pustą listą.
		/// </summary>
		public ActivitySpanProduct()
		{
			this.Spans = new List<IActivitySpan>();
		}

		/// <inheritdoc />
		public bool IsActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return this.Spans.All(s => s.IsActive(baseDate, date));
		}
	}
}
