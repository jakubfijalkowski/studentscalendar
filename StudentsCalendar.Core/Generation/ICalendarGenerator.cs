﻿using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Generator kalendarza.
	/// </summary>
	/// <remarks>
	/// Pełna dokumentacja jest dostępna w opisie interfejsu <see cref="IGenerator"/>.
	/// </remarks>
	public interface ICalendarGenerator
	{
		/// <summary>
		/// Przetwarza szablon, generując pełny kalendarz, aplikuje modyfikatory i
		/// zwraca obiekt wynikowy.
		/// </summary>
		/// <param name="template">Szablon kalendarza.</param>
		/// <param name="context">Kontekst procesu.</param>
		/// <returns></returns>
		IntermediateCalendar Generate(CalendarTemplate template, GenerationContext context);
	}
}
