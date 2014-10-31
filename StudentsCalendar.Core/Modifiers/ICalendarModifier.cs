using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Bazowy interfejs dla modyfikatorów pełnego kalendarza.
	/// Operuje na <see cref="IntermediateCalendar"/>.
	/// </summary>
	public interface ICalendarModifier
	{
		/// <summary>
		/// Aplikuje modyfikator na danych.
		/// </summary>
		/// <param name="data">Kalendarz, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		void Apply(IntermediateCalendar data, GenerationContext context);
	}
}
