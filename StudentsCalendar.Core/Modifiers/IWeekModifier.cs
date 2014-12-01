using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Bazowy interfejs dla modyfikatorów tygodni.
	/// Operuje na <see cref="IntermediateWeek"/>.
	/// </summary>
	public interface IWeekModifier
		: IModifier
	{
		/// <summary>
		/// Przedział aktywności, kiedy dany modyfikator ma być aktywny.
		/// </summary>
		IWeeklyActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Aplikuje modyfikator na danych.
		/// </summary>
		/// <remarks>
		/// Metoda może pracować na danych wejściowych i zwracać obiekt przekazany
		/// jako parametr.
		/// NIE MOŻE odrzucać wpisu, tj. nigdy nie może zwrócić <c>null</c>.
		/// </remarks>
		/// <param name="data">Tydzień, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		/// <returns>Zmodyfikowany obiekt.</returns>
		IntermediateWeek Apply(IntermediateWeek data, GenerationContext context);
	}
}
