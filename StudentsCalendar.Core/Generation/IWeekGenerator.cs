using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{

	/// <summary>
	/// Bazowy interfejs dla generatora tygodni.
	/// </summary>
	public interface IWeekGenerator
	{
		/// <summary>
		/// Przetwarza szablon, generując obiekt pośredniczący dla danego tygodnia,
		/// generuje poszczególne dni, aplikuje modyfikatory i zwraca obiekt wynikowy.
		/// </summary>
		/// <param name="baseDate">Data poniedziałku w danym tygodniu.</param>
		/// <param name="template">Szablon tygodnia.</param>
		/// <param name="context">Kontekst procesu.</param>
		/// <returns></returns>
		IntermediateWeek Generate(LocalDate baseDate, WeekTemplate template, GenerationContext context);
	}
}
