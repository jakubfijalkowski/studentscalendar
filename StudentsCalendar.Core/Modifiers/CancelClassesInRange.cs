using System.Linq;
using NodaTime;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Odwołuje zajęcia w określonym przedziale dat.
	/// </summary>
	public sealed class CancelClassesInRange
		: ICalendarModifier
	{
		/// <summary>
		/// Pobiera lub zmienia datę, od której zajęcia mają zostać anulowane.
		/// </summary>
		public LocalDate StartDate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia datę, do której zajęcia mają zostać anulowane.
		/// </summary>
		public LocalDate EndDate { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public CancelClassesInRange()
		{
			this.StartDate = DateHelper.Today;
			this.EndDate = DateHelper.Today;
		}

		/// <inheritdoc />
		public IntermediateCalendar Apply(IntermediateCalendar data, GenerationContext context)
		{
			var days = data.Weeks
				.SelectMany(w => w.Days)
				.SkipWhile(d => d.Date < this.StartDate)
				.TakeWhile(d => d.Date <= this.EndDate);
			foreach (var day in days)
			{
				day.Classes.Clear();
			}
			return data;
		}
	}
}
