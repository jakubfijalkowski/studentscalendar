using System;
using System.Collections.Generic;
using System.IO;
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
		/// <exception cref="IOException">Rzucane, gdy wystąpił ogólny problem z odczytem szablonu.</exception>
		/// <returns></returns>
		Task<IEnumerable<CalendarEntry>> LoadCalendars();

		/// <summary>
		/// Wczytuje i deserializuje szablon kalendarza.
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy wystąpił ogólny problem z odczytem szablonu.</exception>
		/// <exception cref="CalendarTemplateNotFoundException">Rzucane, gdy wskazany kalendarz nie mógł zostać odnaleziony.</exception>
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
		/// Zapisuje kalendarz.
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy nie uda się wykonać operacji zapisu.</exception>
		/// <param name="template"></param>
		/// <returns></returns>
		Task StoreCalendar(CalendarTemplate template);

		/// <summary>
		/// Usuwa szablon kalendarza.
		/// Metoda nie rzuca wyjątku - kalendarz jest uznawany za usunięty, nawet jeśli
		/// nie powiedzie się usunięcie wpisu z <see cref="IStorage"/>.
		/// </summary>
		/// <param name="calendarId"></param>
		void DeleteTemplate(string calendarId);
	}

	/// <summary>
	/// Wyjątek rzucany, gdy nie można odnaleźć szablonu wskazanego kalendarza.
	/// </summary>
	public sealed class CalendarTemplateNotFoundException
		: IOException
	{
		/// <summary>
		/// Pobiera identyfikator kalendarza.
		/// </summary>
		public string CalendarId { get; private set; }

		public CalendarTemplateNotFoundException(string calendarId)
			: this(calendarId, null)
		{ }

		public CalendarTemplateNotFoundException(string calendarId, Exception innerException)
			: base("Cannot load calendar with id " + calendarId + ".", innerException)
		{
			this.CalendarId = calendarId;
		}
	}
}
