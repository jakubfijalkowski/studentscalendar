using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Bazowy interfejs dla modyfikatorów dni.
	/// Operuje na <see cref="IntermediateDay"/>.
	/// </summary>
	public interface IDayModifier
	{
		/// <summary>
		/// Przedział aktywności, kiedy dany modyfikator ma być aktywny.
		/// </summary>
		IActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Aplikuje modyfikator na danych.
		/// </summary>
		/// <param name="data">Dzień, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		void Apply(IntermediateDay data, GenerationContext context);
	}
}
