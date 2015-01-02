using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Generator dni.
	/// </summary>
	/// <remarks>
	/// Pełna dokumentacja jest dostępna w opisie interfejsu <see cref="IGenerator"/>.
	/// </remarks>
	public interface IDayGenerator
		: IGenerator
	{
		/// <summary>
		/// Przetwarza szablon, generując obiekt pośredniczący dla danej daty, generuje
		/// zajęcia dla danego dnia, aplikuje modyfikatory i zwraca obiekt wynikowy.
		/// </summary>
		/// <param name="dayDate">Data dnia do wygenerowania.</param>
		/// <param name="template">Szablon dnia.</param>
		/// <param name="context">Kontekst procesu.</param>
		/// <returns></returns>
		IntermediateDay Generate(LocalDate dayDate, DayTemplate template, GenerationContext context);
	}
}
