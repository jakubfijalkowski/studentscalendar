using System;

namespace StudentsCalendar.Core.Logging
{
	/// <summary>
	/// Poziom wpisu logu.
	/// </summary>
	public enum LogLevel
	{
		Debug = 0,
		Info,
		Warn,
		Error,
		Fatal
	}

	/// <summary>
	/// Wpis w logu.
	/// </summary>
	public sealed class LogEntry
	{
		/// <summary>
		/// Poziom wpisu.
		/// </summary>
		public LogLevel Level { get; set; }

		/// <summary>
		/// Data powstania wpisu.
		/// </summary>
		public DateTime Date { get; set; }

		/// <summary>
		/// Wiadomość.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// Wyjątek, który został przekazany.
		/// </summary>
		public Exception Exception { get; set; }
	}
}
