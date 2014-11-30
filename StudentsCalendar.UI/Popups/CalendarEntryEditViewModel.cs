using Caliburn.Micro;
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
				this.NotifyOfPropertyChange(() => this.Template);
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
	}
}
