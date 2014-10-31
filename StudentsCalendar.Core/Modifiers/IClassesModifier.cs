using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Bazowy interfejs dla modyfikatorów zajęć/wykładów.
	/// Operuje na <see cref="IntermediateClasses"/>.
	/// </summary>
	public interface IClassesModifier
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
		/// </remarks>
		/// <param name="data">Zajęcia, na którym modyfikator powinien pracować.</param>
		/// <param name="context">Kontekst procesu generowania.</param>
		/// <returns>Zmodyfikowany obiekt -lub- <c>null</c>, gdy dane zajęcia nie powinny zostać wygenerowane.</returns>
		IntermediateClasses Apply(IntermediateClasses data, GenerationContext context);
	}
}
