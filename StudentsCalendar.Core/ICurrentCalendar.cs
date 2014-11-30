using System.Threading.Tasks;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Odpowiada za wczytanie i generowanie właściwego kalendarza.
	/// </summary>
	public interface ICurrentCalendar
	{
		/// <summary>
		/// Szablon na podstawie którego generowano kalendarz.
		/// </summary>
		CalendarTemplate Template { get; }

		/// <summary>
		/// Wynik procesu generowania kalendarza.
		/// </summary>
		GenerationResults Results { get; }

		/// <summary>
		/// Wygenerowany kalendarz.
		/// </summary>
		FinalCalendar Calendar { get; }

		/// <summary>
		/// Uaktualnia wygenerowany kalendarz.
		/// </summary>
		/// <remarks>
		/// TODO:
		/// W praktyce to powinno być realizowane przez mechanizm zdarzeń. Nie opłaca się
		/// go jednak wprowadzać tylko dla tego jednego miejsca.
		/// </remarks>
		/// <param name="calendarId"></param>
		Task Update(string calendarId);
	}
}
