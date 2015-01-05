using System.Collections.Generic;

namespace StudentsCalendar.UI.Logging
{
	/// <summary>
	/// Konfiguracja podsystemu logowania.
	/// </summary>
	public sealed class LoggerConfiguration
	{
		private readonly List<ITarget> _Targets = new List<ITarget>();

		/// <summary>
		/// Minimalny poziom akceptowanych logów.
		/// </summary>
		public LogLevel MinLevel { get; set; }

		/// <summary>
		/// Maksymalny poziom akceptowanych logów.
		/// </summary>
		public LogLevel MaxLevel { get; set; }

		/// <summary>
		/// Lista miejsc, gdzie log zostanie zapisany.
		/// </summary>
		public IList<ITarget> Targets
		{
			get { return this._Targets; }
		}

		public LoggerConfiguration()
		{
			this.MinLevel = LogLevel.Debug;
			this.MaxLevel = LogLevel.Fatal;
		}
	}
}
