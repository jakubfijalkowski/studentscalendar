using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Storage
{
	/// <summary>
	/// Relatywnie niskopoziomowy interfejs odpowiedzialny za wczytywanie i zapisywanie danych
	/// aplikacji.
	/// </summary>
	public interface IContentProvider
	{
		/// <summary>
		/// Wczytuje i deserializuje dostępne kalendarze.
		/// </summary>
		/// <returns></returns>
		Task<IReadOnlyList<CalendarEntry>> LoadCalendars();

		/// <summary>
		/// Wczytuje i deserializuje szablon kalendarza.
		/// </summary>
		/// <param name="calendarId"></param>
		/// <returns></returns>
		Task<CalendarTemplate> LoadTemplate(string calendarId);
	}
}
