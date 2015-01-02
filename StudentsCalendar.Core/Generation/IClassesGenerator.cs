using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Generator zajęć.
	/// </summary>
	/// <remarks>
	/// Pełna dokumentacja jest dostępna w opisie interfejsu <see cref="IGenerator"/>.
	/// </remarks>
	public interface IClassesGenerator
		: IGenerator
	{
		/// <summary>
		/// Przetwarza szablon, tworząc obiekt dla konkretnej daty, aplikuje odpowiednie
		/// modyfikatory i zwraca obiekt wynikowy.
		/// </summary>
		/// <param name="classesDate">Data zajęć.</param>
		/// <param name="template">Szablon zajęć.</param>
		/// <param name="context">Kontekst procesu.</param>
		/// <returns></returns>
		IntermediateClasses Generate(LocalDate classesDate, ClassesTemplate template, GenerationContext context);
	}
}
