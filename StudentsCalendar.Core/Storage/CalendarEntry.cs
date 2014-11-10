using NodaTime;

namespace StudentsCalendar.Core.Storage
{
	/// <summary>
	/// Opisuje wpis w bazie kalendarzy, który służy do identyfikacji właściwych szablonów.
	/// Pozwala opóźnić wczytanie szablonu głównego, i pominąć wczytywanie pozostałych szablonów.
	/// </summary>
	public sealed class CalendarEntry
	{
		private readonly string _Id;

		/// <summary>
		/// Pobiera identyfikator wpisu.
		/// </summary>
		public string Id
		{
			get { return this._Id; }
		}

		/// <summary>
		/// Pobiera lub zmienia nazwę kalendarza.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Pobiera lub zmienia datę początku aktywności kalendarza.
		/// </summary>
		public LocalDate StartDate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia datę końca aktywności kalendarza.
		/// </summary>
		public LocalDate EndDate { get; set; }

		/// <summary>
		/// Wskazuje, czy kalendarz jest aktywny, czy nie.
		/// </summary>
		/// <remarks>
		/// W ramach aplikacji może istnieć 
		/// </remarks>
		public bool IsActive { get; set; }

		public CalendarEntry(string id)
		{
			this._Id = id;
		}
	}
}
