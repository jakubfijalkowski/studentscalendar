using System;
using System.IO;
using System.Threading.Tasks;
using StudentsCalendar.Core.Platform;

namespace StudentsCalendar.Desktop.Platform
{
	/// <summary>
	/// Implementacja <see cref="IStorage"/>, która przechowuje dane w folderze ustawień użytkownika.
	/// </summary>
	sealed class UserStorage
		: IStorage
	{
		private const string CalendarsFile = "Calendars.json";
		private readonly string DataPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"StudentsCalendar");

		/// <inheritdoc />
		public Task<Stream> LoadEntries()
		{
			this.EnsureFolderExists();
			string filePath = Path.Combine(DataPath, CalendarsFile);
			return Task.FromResult<Stream>(new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read));
		}

		/// <inheritdoc />
		public Task<Stream> LoadCalendar(string id)
		{
			this.EnsureFolderExists();
			string filePath = Path.Combine(DataPath, id + ".json");
			return Task.FromResult<Stream>(new FileStream(filePath, FileMode.Open, FileAccess.Read));
		}

		private void EnsureFolderExists()
		{
			if (!Directory.Exists(DataPath))
			{
				try
				{
					Directory.CreateDirectory(DataPath);
				}
				catch
				{
				}
			}
		}
	}
}
