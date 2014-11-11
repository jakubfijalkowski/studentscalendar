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
		private readonly string DataPath = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"StudentsCalendar");

		/// <inheritdoc />
		public Task<Stream> OpenRead(string entryId)
		{
			return this.AccessFile(entryId, FileMode.Open, FileAccess.Read);
		}

		/// <inheritdoc />
		public Task<Stream> OpenOrCreate(string entryId)
		{
			return this.AccessFile(entryId, FileMode.OpenOrCreate, FileAccess.Read);
		}

		/// <inheritdoc />
		public Task<Stream> OpenWrite(string entryId)
		{
			return this.AccessFile(entryId, FileMode.Create, FileAccess.Write);
		}

		/// <inheritdoc />
		public Task DeleteEntry(string entryId)
		{
			var filePath = Path.Combine(entryId);
			if (File.Exists(filePath))
			{
				try
				{
					File.Delete(filePath);
				}
				catch
				{ }
			}
			return Task.FromResult<object>(null);
		}

		private Task<Stream> AccessFile(string name, FileMode mode, FileAccess access)
		{
			this.EnsureFolderExists();
			string filePath = Path.Combine(DataPath, name);
			return Task.FromResult<Stream>(new FileStream(filePath, mode, access));
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
