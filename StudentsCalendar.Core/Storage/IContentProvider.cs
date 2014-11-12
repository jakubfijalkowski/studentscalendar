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
		Task<IEnumerable<CalendarEntry>> LoadCalendars();

		/// <summary>
		/// Wczytuje i deserializuje szablon kalendarza.
		/// </summary>
		/// <param name="calendarId"></param>
		/// <returns></returns>
		Task<CalendarTemplate> LoadTemplate(string calendarId);

		/// <summary>
		/// Zapisuje nową listę kalendarzy do pliku.
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy nie uda się wykonać operacji zapisu.</exception>
		/// <param name="entries"></param>
		/// <returns></returns>
		Task StoreCalendars(IEnumerable<CalendarEntry> entries);

		/// <summary>
		/// Usuwa szablon kalendarza.
		/// Metoda nie rzuca wyjątku - kalendarz jest uznawany za usunięty, nawet jeśli
		/// nie powiedzie się usunięcie wpisu z <see cref="IStorage"/>
		/// </summary>
		/// <param name="calendarId"></param>
		void DeleteTemplate(string calendarId);
	}
}
