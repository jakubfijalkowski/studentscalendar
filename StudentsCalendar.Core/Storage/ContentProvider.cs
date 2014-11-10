using System.Collections.Generic;
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
		public async Task<IReadOnlyList<CalendarEntry>> LoadCalendars()
		{
			using (var stream = await this.Storage.LoadEntries())
			using (var reader = new JsonTextReader(new StreamReader(stream)))
			{
				return await Task.Run(() => this.Serializer.Deserialize<List<CalendarEntry>>(reader));
			}
		}

		/// <inheritdoc />
		public async Task<CalendarTemplate> LoadTemplate(string calendarId)
		{
			using (var stream = await this.Storage.LoadCalendar(calendarId))
			using (var reader = new JsonTextReader(new StreamReader(stream)))
			{
				return await Task.Run(() => this.Serializer.Deserialize<CalendarTemplate>(reader));
			}
		}
	}
}
