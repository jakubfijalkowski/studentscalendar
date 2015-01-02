using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Generator tygodni.
	/// </summary>
	/// <remarks>
	/// Pełna dokumentacja jest dostępna w opisie interfejsu <see cref="IGenerator"/>.
	/// </remarks>
	public interface IWeekGenerator
	{
		/// <summary>
		/// Przetwarza szablon, generując obiekt pośredniczący dla danego tygodnia,
		/// generuje poszczególne dni, aplikuje modyfikatory i zwraca obiekt wynikowy.
		/// </summary>
		/// <param name="weekDate">Data poniedziałku w danym tygodniu.</param>
		/// <param name="template">Szablon tygodnia.</param>
		/// <param name="context">Kontekst procesu.</param>
		/// <returns></returns>
		IntermediateWeek Generate(LocalDate weekDate, WeekTemplate template, GenerationContext context);
	}
}
