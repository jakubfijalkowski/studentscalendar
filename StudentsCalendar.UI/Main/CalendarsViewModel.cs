using System.Collections.Generic;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// ViewModel listy kalendarzy użytkownika.
	/// </summary>
	public sealed class CalendarsViewModel
		: Screen, IViewModel
	{
		private readonly IShell Shell;
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
		/// <param name="shell"></param>
		/// <param name="calendars"></param>
		public CalendarsViewModel(IShell shell, ICalendarsManager calendars)
		{
			this.Shell = shell;
			this.Calendars = calendars;
		}

		/// <summary>
		/// Wyświetla okno edycji dla wskazanego wpisu.
		/// </summary>
		/// <param name="entry"></param>
		public void EditEntry(CalendarEntry entry)
		{
			this.Shell.ShowPopup<Popups.CalendarEntryEditViewModel>().Context = entry;
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
				var ignored = this.Shell.ShowDialog(new ErrorDialog
				{
					Title = "Nie można usunąć wpisu.",
					Message = "Nie udało się zapisać zmian, spróbuj ponownie później."
				});
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
			catch (CalendarTemplateNotFoundException)
			{
				var ignored = this.Shell.ShowDialog(new ErrorDialog
				{
					Title = "Operacja nie powiodła się.",
					Message = "Nie udało się odczytać szablonu. Prawdopodobnie został uszkodzony. Odtwórz go lub rozważ usunięcie wpisu."
				});
			}
			catch
			{
				var ignored = this.Shell.ShowDialog(new ErrorDialog
				{
					Title = "Nie można usunąć wpisu.",
					Message = "Nie udało się zapisać zmian, spróbuj ponownie później."
				});
			}
		}
	}
}
