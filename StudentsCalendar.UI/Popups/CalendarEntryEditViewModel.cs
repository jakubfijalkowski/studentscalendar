﻿using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Dialogs;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// ViewModel do edycji kaneldarza.
	/// </summary>
	public sealed class CalendarEntryEditViewModel
		: Screen, IViewModel, IHaveContext<CalendarTemplate>
	{
		private readonly IShell Shell;
		private readonly ICalendarsManager Calendars;

		private EditableObject<CalendarTemplate> EditableObject;

		/// <inheritdoc />
		public CalendarTemplate Context
		{
			get
			{
				return this.EditableObject != null ? this.EditableObject.Data : null;
			}
			set
			{
				this.EditableObject = new EditableObject<CalendarTemplate>(value);
				this.NotifyOfPropertyChange(() => this.Template);
			}
		}

		/// <summary>
		/// Pobiera obiekt, który należy edytować.
		/// </summary>
		public CalendarTemplate Template
		{
			get { return this.EditableObject.Data; }
		}

		/// <summary>
		/// Inicjalizuje ViewModel niezbędnymi zależnościami.
		/// </summary>
		/// <param name="shell"></param>
		/// <param name="calendars"></param>
		public CalendarEntryEditViewModel(IShell shell, ICalendarsManager calendars)
		{
			this.Shell = shell;
			this.Calendars = calendars;
		}

		/// <summary>
		/// Zapisuje zmiany do "backing store".
		/// </summary>
		public async void Save()
		{
			try
			{
				await this.Calendars.SaveChanges(this.Template);
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
	}
}
