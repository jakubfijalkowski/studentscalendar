﻿using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using StudentsCalendar.Core.Platform;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Storage
{
	/// <summary>
	/// Podstawowa implementacja <see cref="IContentProvider"/>.
	/// </summary>
	public sealed class ContentProvider
		: IContentProvider
	{
		private const string CalendarsEntryId = "Calendars.json";
		private const string TemplateEntryIdFormat = "{0}.json";

		private readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.Objects
			}.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb)
		);
		private readonly IStorage Storage;

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="storage"></param>
		public ContentProvider(IStorage storage)
		{
			this.Storage = storage;
		}

		/// <inheritdoc />
		public async Task<IEnumerable<CalendarEntry>> LoadCalendars()
		{
			var stream = await this.Storage.OpenOrCreate(CalendarsEntryId);
			using (var reader = new JsonTextReader(new StreamReader(stream)))
			{
				return await Task.Run(() => this.Serializer.Deserialize<List<CalendarEntry>>(reader));
			}
		}

		/// <inheritdoc />
		public async Task<CalendarTemplate> LoadTemplate(string calendarId)
		{
			try
			{
				var stream = await this.Storage.OpenRead(string.Format(TemplateEntryIdFormat, calendarId));
				using (var reader = new JsonTextReader(new StreamReader(stream)))
				{
					return await Task.Run(() => this.Serializer.Deserialize<CalendarTemplate>(reader));
				}
			}
			catch (FileNotFoundException ex) //TODO: consider using more generic exception here
			{
				throw new CalendarTemplateNotFoundException(calendarId, ex);
			}
		}

		/// <inheritdoc />
		public async Task StoreCalendars(IEnumerable<CalendarEntry> entries)
		{
			var stream = await this.Storage.OpenWrite(CalendarsEntryId);
			using (var writer = new JsonTextWriter(new StreamWriter(stream)))
			{
				await Task.Run(() => this.Serializer.Serialize(writer, entries));
			}
		}

		/// <inheritdoc />
		public async Task StoreCalendar(CalendarTemplate template)
		{
			var stream = await this.Storage.OpenWrite(string.Format(TemplateEntryIdFormat, template.Id));
			using (var writer = new JsonTextWriter(new StreamWriter(stream)))
			{
				await Task.Run(() => this.Serializer.Serialize(writer, template));
			}
		}

		/// <inheritdoc />
		public void DeleteTemplate(string calendarId)
		{
			this.Storage.DeleteEntry(string.Format(TemplateEntryIdFormat, calendarId));
		}
	}
}
