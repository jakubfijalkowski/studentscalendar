using System.Collections.Generic;
using StudentsCalendar.Core.Modifiers;

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
		/// Szablon na dany dzień znajduje się pod indeksem zwracanym przez <see cref="IsoDayOfWeekExtension.ToIndex"/>.
		/// </remarks>
		public IReadOnlyList<DayTemplate> Days { get; set; }

		/// <summary>
		/// Lista modyfikatorów przypisana do szablonu tygodnia.
		/// </summary>
		public IList<IWeekModifier> Modifiers { get; set; }
	}
}
