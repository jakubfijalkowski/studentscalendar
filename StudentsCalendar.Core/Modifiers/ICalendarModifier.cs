using StudentsCalendar.Core.Generation;
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
		/// <remarks>
		/// Metoda może pracować na danych wejściowych i zwracać obiekt przekazany
		/// jako parametr.
		/// NIE MOŻE odrzucać wpisu, tj. nigdy nie może zwrócić <c>null</c>.
		/// </remarks>
		/// <param name="data">Kalendarz, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		/// <returns>Zmodyfikowany obiekt.</returns>
		IntermediateCalendar Apply(IntermediateCalendar data, GenerationContext context);
	}
}
