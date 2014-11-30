using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// ViewModel do edycji kaneldarza.
	/// </summary>
	public sealed class CalendarEntryEditViewModel
		: Screen, IViewModel
	{
		private const int EditStartHour = 0;
		private const int EditEndHour = 24;

		private readonly IShell Shell;

		private readonly IContentProvider ContentProvider;
		private readonly ICalendarsManager Calendars;
		private readonly ICurrentCalendar CurrentCalendar;

		private string _CalendarId;
		private EditableObject<CalendarTemplate> EditableObject;

		/// <summary>
		/// Pobiera lub zmienia identyfikator kalendarza do edycji.
		/// </summary>
		public string CalendarId
		{
			get { return this._CalendarId; }
			set
			{
				this._CalendarId = value;
				this.LoadTemplate();
			}
		}

		/// <summary>
		/// Pobiera obiekt, który należy edytować.
		/// </summary>
		public CalendarTemplate Template
		{
			get { return this.EditableObject != null ? this.EditableObject.Data : null; }
		}

		/// <summary>
		/// Pobiera listę slotów wyświetlanych na ekranie.
		/// </summary>
		public IReadOnlyList<LocalTime> TimeSlots { get; private set; }

		/// <summary>
		/// Pobiera listę slotów do edycji.
		/// </summary>
		public IReadOnlyList<CalendarEditSlot> EditSlots { get; private set; }

		/// <summary>
		/// Inicjalizuje ViewModel niezbędnymi zależnościami.
		/// </summary>
		/// <param name="shell"></param>
		/// <param name="calendars"></param>
		public CalendarEntryEditViewModel(IShell shell, IContentProvider contentProvider, ICalendarsManager calendars,
			ICurrentCalendar currentCalendar)
		{
			this.Shell = shell;

			this.ContentProvider = contentProvider;
			this.Calendars = calendars;
			this.CurrentCalendar = currentCalendar;
		}

		/// <summary>
		/// Zapisuje zmiany do "backing store".
		/// </summary>
		public async void Save()
		{
			try
			{
				await this.Calendars.SaveChanges(this.Template);

				await this.CurrentCalendar.Update(this.Template.Id);

				this.TryClose();
			}
			catch
			{
				var ignored = this.Shell.ShowDialog(new ErrorDialog
				{
					Title = "Nie udało się zachować zmian.",
					Message = "Spróbuj później lub skontaktuj się z autorem aplikacji."
				});
			}
		}

		/// <summary>
		/// Anuluje zmiany i zamyka okno.
		/// </summary>
		public void Cancel()
		{
			this.EditableObject.Rollback();
			this.TryClose();
		}

		private async void LoadTemplate()
		{
			try
			{
				var template = await this.ContentProvider.LoadTemplate(this.CalendarId);
				this.EditableObject = new EditableObject<CalendarTemplate>(template);

				this.BuildEditTemplate();

				this.NotifyOfPropertyChange(() => this.Template);
				this.NotifyOfPropertyChange(() => this.EditSlots);
			}
			catch
			{
				var ignored = this.Shell.ShowDialog(new ErrorDialog
				{
					Title = "Nie udało się wczytać kalendarza.",
					Message = "Sprawdź, czy dane aplikacji nie zostały uszkodzone. Jeśli tak się stało, usuń i utwórz kalendarz ponownie."
				}).ContinueWith(t => this.TryClose());
			}
		}

		private void BuildEditTemplate()
		{
			int hours = EditEndHour - EditStartHour;
			this.TimeSlots = Enumerable
				.Range(EditStartHour, hours)
				.Select(h => new LocalTime(h, 0))
				.ToList();
			this.EditSlots =
				(from i in Enumerable.Range(0, hours * 7)
				 let day = (i % 7).ToDayOfWeek()
				 let hour = i / 7 + EditStartHour
				 select new CalendarEditSlot(day, new LocalTime(hour, 0))
				).ToList();
		}
	}
}
