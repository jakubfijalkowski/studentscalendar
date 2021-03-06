﻿using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Konwertuje kalendarz z formy pośredniej do finalnej. Służy tylko do zmapowania
	/// obiektów pośrednich na obiekty finalne.
	/// </summary>
	public interface ICalendarFinalizer
	{
		/// <summary>
		/// Konwertuje kalendarz z formy pośredniej do finalnej. 
		/// </summary>
		/// <param name="calendar"></param>
		/// <returns></returns>
		FinalCalendar Finalize(IntermediateCalendar calendar);
	}
}
