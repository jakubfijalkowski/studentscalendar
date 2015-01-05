using System;
using System.IO;
using StudentsCalendar.Core.Logging;

namespace StudentsCalendar.Desktop
{
	/// <summary>
	/// Cel będący plikiem.
	/// </summary>
	public sealed class FileTarget
		: ITarget
	{
		public const string LogFormat = "[{0}][{1:u}] {2}";
		public static readonly string LogPath = Path.Combine(Platform.UserStorage.DataPath, "Log.txt");

		/// <inheritdoc />
		public void Write(LogEntry entry)
		{
			string contents = string.Format(LogFormat, entry.Level, entry.Date, entry.Message);
			if (entry.Exception != null)
			{
				contents += Environment.NewLine + entry.Exception.ToString();
			}
			this.Write(contents);
		}

		private void Write(string contents)
		{
			try
			{
				File.AppendAllText(LogPath, contents + Environment.NewLine);
			}
			catch
			{ }
		}
	}
}
