using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Silnik tworzenia kalendarza.
	/// </summary>
	/// <remarks>
	/// Silnik odpowiada za wygenerowanie form pośrednich, sprawdzenie poprawności,
	/// wygenerowanie logów, przycięcie zakresu itp. Na koniec powinien sfinalizować
	/// kalendarz, by uzyskać formę niezmienną. Inaczej rzecz ujmując - spaja wszystkie
	/// podsytemy aplikacji.
	/// </remarks>
	public interface ICalendarEngine
	{
		/// <summary>
		/// Przeprowadza proces generowania kalendarza.
		/// </summary>
		/// <param name="template"></param>
		/// <returns></returns>
		GenerationResults Generate(CalendarTemplate template);
	}

	/// <summary>
	/// Wynik generowania kalendarza.
	/// </summary>
	public class GenerationResults
	{
		private readonly FinalCalendar _Calendar;

		/// <summary>
		/// Pobiera wynikowy kalendarz.
		/// </summary>
		public FinalCalendar Calendar
		{
			get { return this._Calendar; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi właściwościami.
		/// </summary>
		/// <param name="calendar"></param>
		public GenerationResults(FinalCalendar calendar)
		{
			this._Calendar = calendar;
		}
	}
}
