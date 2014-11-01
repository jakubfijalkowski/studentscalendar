using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{

	/// <summary>
	/// Bazowy interfejs dla generatora dni.
	/// </summary>
	public interface IDayGenerator
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
