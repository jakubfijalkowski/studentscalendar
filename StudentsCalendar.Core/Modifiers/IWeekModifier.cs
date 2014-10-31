using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Bazowy interfejs dla modyfikatorów tygodni.
	/// Operuje na <see cref="IntermediateWeek"/>.
	/// </summary>
	public interface IWeekModifier
	{
		/// <summary>
		/// Przedział aktywności, kiedy dany modyfikator ma być aktywny.
		/// </summary>
		IWeekActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Aplikuje modyfikator na danych.
		/// </summary>
		/// <param name="data">Tydzień, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		void Apply(IntermediateWeek data, GenerationContext context);
	}
}
