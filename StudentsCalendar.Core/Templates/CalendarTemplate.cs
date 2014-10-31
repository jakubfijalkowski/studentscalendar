using NodaTime;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon kalendarza.
	/// </summary>
	public sealed class CalendarTemplate
	{
		/// <summary>
		/// Pobiera lub zmienia bazowy szablon tygodniowy.
		/// </summary>
		public WeekTemplate WeekTemplate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia początkową datę aktywności kalendarza.
		/// </summary>
		public LocalDate StartDate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia końcową datę aktywności kalendarza.
		/// </summary>
		public LocalDate EndDate { get; set; }
	}
}
