using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using StudentsCalendar.Core.Logging;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Podstawowa implementacja <see cref="ICalendarsManager"/>
	/// </summary>
	public sealed class CalendarsManager
		: ICalendarsManager
	{
		private readonly IContentProvider ContentProvider;
		private readonly ILogger Logger;

		private ObservableCollection<CalendarEntry> _Entries;

		private bool IsInitialized;

		/// <inheritdoc />
		public CalendarEntry ActiveEntry { get; private set; }

		/// <inheritdoc />
		public IReadOnlyList<CalendarEntry> Entries
		{
			get { return this._Entries; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="contentProvider"></param>
		public CalendarsManager(IContentProvider contentProvider, ILogger logger)
		{
			this.ContentProvider = contentProvider;
			this.Logger = logger;
		}

		/// <inheritdoc />
		public async Task Initialize()
		{
			if (this.IsInitialized)
			{
				throw new InvalidOperationException();
			}
			this.IsInitialized = true;

			IEnumerable<CalendarEntry> loadedEntries = null;
			try
			{
				loadedEntries = await this.ContentProvider.LoadCalendars();
			}
			catch (Exception ex)
			{
				this.Logger.Error(ex, "Cannot load calendars in IContentProvider.");
				throw;
			}
			finally
			{
				this._Entries = new ObservableCollection<CalendarEntry>(loadedEntries ?? Enumerable.Empty<CalendarEntry>());
				this.ActiveEntry = this.Entries.FirstOrDefault(e => e.IsActive);
			}
		}

		/// <inheritdoc />
		public async Task SaveChanges(CalendarTemplate template)
		{
			var entry = this.Entries.FirstOrDefault(e => e.Id == template.Id);

			if (entry == null)
			{
				entry = new CalendarEntry(template.Id);
				this._Entries.Add(entry);
			}

			entry.Name = template.Name;
			entry.StartDate = template.StartDate;
			entry.EndDate = template.EndDate;

			try
			{
				await this.ContentProvider.StoreCalendar(template);
				await this.ContentProvider.StoreCalendars(this.Entries);
			}
			catch (Exception ex)
			{
				this.Logger.Error(ex, "Cannot save changes to the calendar {0}.", template.Id);
				throw;
			}
		}

		/// <inheritdoc />
		public async Task DeleteEntry(CalendarEntry entry)
		{
			if (entry.IsActive)
			{
				throw new InvalidOperationException("Cannot delete active entry.");
			}

			// Try to remove the calendar from backing store first,
			// if it fails - the list will stay intact.

			try
			{
				var newList = this.Entries.Where(e => e != entry);
				await this.ContentProvider.StoreCalendars(newList);
				this._Entries.Remove(entry);

				this.ContentProvider.DeleteTemplate(entry.Id);
			}
			catch (Exception ex)
			{
				this.Logger.Error(ex, "Cannot delete calendar {0}.", entry.Id);
				throw;
			}
		}

		/// <inheritdoc />
		public async Task MakeActive(CalendarEntry entry)
		{
			var old = this.ActiveEntry;
			if (this.ActiveEntry != null)
			{
				this.ActiveEntry.IsActive = false;
			}
			entry.IsActive = true;
			this.ActiveEntry = entry;

			try
			{
				await this.ContentProvider.StoreCalendars(this.Entries);
			}
			catch (Exception ex)
			{
				this.Logger.Error(ex, "Cannot make calendar {0} active.", entry.Id);

				entry.IsActive = false;
				old.IsActive = true;
				this.ActiveEntry = old;
				throw;
			}
		}
	}
}
