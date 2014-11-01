using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Bazowy interfejs dla generatora zajęć.
	/// </summary>
	public interface IClassesGenerator
	{
		/// <summary>
		/// Przetwarza szablon, tworząc obiekt dla konkretnej daty, aplikuje odpowiednie
		/// modyfikatory i zwraca obiekt wynikowy.
		/// </summary>
		/// <param name="date">Data zajęć.</param>
		/// <param name="template">Szablon zajęć.</param>
		/// <param name="context">Kontekst procesu.</param>
		/// <returns></returns>
		IntermediateClasses Generate(LocalDate date, ClassesTemplate template, GenerationContext context);
	}
}
