using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using NodaTime;
using NodaTime.Serialization.JsonNet;

namespace StudentsCalendar.UI
{
	/// <summary>
	/// Udostępnia mechanizm do przywrócenia danych obiektu z momentu utworzenia.
	/// </summary>
	/// <remarks>
	/// Używa do tego serializacji do formatu Bson za pomocą Json.NET.
	/// </remarks>
	/// <typeparam name="TData"></typeparam>
	public sealed class EditableObject<TData>
	{
		private readonly JsonSerializer Serializer = JsonSerializer.Create(new JsonSerializerSettings
		{
			TypeNameHandling = TypeNameHandling.Objects,
			ObjectCreationHandling = ObjectCreationHandling.Replace
		}.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

		private readonly byte[] OriginalData;
		private readonly TData _Data;

		/// <summary>
		/// Pobiera obiekt do edycji.
		/// </summary>
		public TData Data
		{
			get { return this._Data; }
		}

		public EditableObject(TData obj)
		{
			this._Data = obj;
			using (var stream = new MemoryStream())
			{
				using (var writer = new BsonWriter(stream))
				{
					this.Serializer.Serialize(writer, obj);
				}
				this.OriginalData = stream.ToArray();
			}
		}

		/// <summary>
		/// Cofa zmiany wprowadzone w obiekcie.
		/// </summary>
		public void Rollback()
		{
			using (var stream = new MemoryStream(this.OriginalData))
			using (var reader = new BsonReader(stream))
			{
				this.Serializer.Populate(reader, this.Data);
			}
		}
	}
}
