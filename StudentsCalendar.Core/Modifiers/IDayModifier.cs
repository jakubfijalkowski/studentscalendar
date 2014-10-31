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
		/// <remarks>
		/// Metoda może pracować na danych wejściowych i zwracać obiekt przekazany
		/// jako parametr.
		/// NIE MOŻE odrzucać wpisu, tj. nigdy nie może zwrócić <c>null</c>.
		/// </remarks>
		/// <param name="data">Dzień, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		/// <returns>Zmodyfikowany obiekt.</returns>
		IntermediateDay Apply(IntermediateDay data, GenerationContext context);
	}
}
