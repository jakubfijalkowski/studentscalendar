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
		: Screen, IViewModel
	{
		private readonly ICalendarsManager Calendars;

		/// <summary>
		/// Pobiera listę kalendarzy użytkownika.
		/// </summary>
		public IReadOnlyList<CalendarEntry> Entries
		{
			get
			{
				return this.Calendars.Entries;
			}
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="calendars"></param>
		public CalendarsViewModel(ICalendarsManager calendars)
		{
			this.Calendars = calendars;
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
		public async void DeleteEntry(CalendarEntry entry)
		{
			try
			{
				await this.Calendars.DeleteEntry(entry);
			}
			catch
			{
				//TODO: handle error
			}
		}

		/// <summary>
		/// Ustawia wpis jako "aktywny".
		/// </summary>
		/// <param name="entry"></param>
		public async void MakeActive(CalendarEntry entry)
		{
			try
			{
				await this.Calendars.MakeActive(entry);
			}
			catch
			{
				//TODO: handle error
			}
		}
	}
}
