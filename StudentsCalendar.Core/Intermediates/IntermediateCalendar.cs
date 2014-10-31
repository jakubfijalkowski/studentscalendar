using NodaTime;

namespace StudentsCalendar.Core.Intermediates
{
	/// <summary>
	/// Opis kalendarza - dane pośredniczące.
	/// </summary>
	public sealed class IntermediateCalendar
	{
		/// <summary>
		/// Pobiera lub zmienia opis tygodnia.
		/// </summary>
		public IntermediateWeek WeekDescription { get; set; }

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
