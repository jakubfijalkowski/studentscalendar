using System.Collections.Generic;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon tygodniowy.
	/// </summary>
	public sealed class WeekTemplate
	{
		/// <summary>
		/// Pobiera lub zmienia listę szablonów.
		/// </summary>
		/// <remarks>
		/// Szablon na dany dzień znajduje się pod indeksem zwracanym przez <c>IsoDayOfWeek.ToIndex()</c>.
		/// </remarks>
		public IReadOnlyList<DayTemplate> Days { get; set; }
	}
}
