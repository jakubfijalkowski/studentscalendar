using System.IO;
using System.Threading.Tasks;
using StudentsCalendar.Core.Platform;

namespace StudentsCalendar.Desktop.Platform
{
	/// <summary>
	/// Testowa implementacja <see cref="IStorage"/> wczytująca dane z pliku testowego.
	/// </summary>
	sealed class SampleStorage
		: IStorage
	{
		/// <inheritdoc />
		public Task<Stream> LoadCalendars()
		{
			return Task.FromResult<Stream>(File.OpenRead("Calendars.json"));
		}
	}
}
