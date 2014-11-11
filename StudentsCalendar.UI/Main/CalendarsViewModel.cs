using System.Collections.Generic;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Storage;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// ViewModel listy kalendarzy użytkownika.
	/// </summary>
	public sealed class CalendarsViewModel
		: Screen, IMainScreen
	{
		private readonly ICalendarsManager Calendars;

		/// <summary>
		/// Pobiera listę kalendarzy użytkownika.
		/// </summary>
		public IReadOnlyList<CalendarEntry> Entries { get; private set; }

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="calendars"></param>
		public CalendarsViewModel(ICalendarsManager calendars)
		{
			this.Calendars = calendars;
			this.Entries = this.Calendars.Entries;
		}

		/// <summary>
		/// Wyświetla okno edycji dla wskazanego wpisu.
		/// </summary>
		/// <param name="entry"></param>
		public void EditEntry(CalendarEntry entry)
		{

		}

		/// <summary>
		/// Usuwa wskazany wpis.
		/// </summary>
		/// <param name="entry"></param>
		public void DeleteEntry(CalendarEntry entry)
		{

		}

		/// <summary>
		/// Ustawia wpis jako "aktywny".
		/// </summary>
		/// <param name="entry"></param>
		public void MakeActive(CalendarEntry entry)
		{

		}
	}
}
