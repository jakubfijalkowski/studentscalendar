using NodaTime;

namespace StudentsCalendar.Core.Finals
{
	/// <summary>
	/// Opis zajęć/wykładu.
	/// </summary>
	public sealed class FinalClasses
	{
		private readonly LocalDateTime _StartDate;
		private readonly LocalDateTime _EndDate;
		private readonly string _ShortName;
		private readonly string _LongName;
		private readonly FinalLecturer _Lecturer;
		private readonly FinalLocation _Location;
		private readonly string _Notes;

		/// <summary>
		/// Pobiera datę rozpoczęcia zajęć.
		/// </summary>
		public LocalDateTime StartDate
		{
			get { return this._StartDate; }
		}

		/// <summary>
		/// Pobiera datę zakończenia zajęć.
		/// </summary>
		public LocalDateTime EndDate
		{
			get { return this._EndDate; }
		}

		/// <summary>
		/// Pobiera krótką nazwę.
		/// </summary>
		public string ShortName
		{
			get { return this._ShortName; }
		}

		/// <summary>
		/// Pobiera pełną nazwę.
		/// </summary>
		public string LongName
		{
			get { return this._LongName; }
		}

		/// <summary>
		/// Pobiera dane wykładowcy.
		/// </summary>
		public FinalLecturer Lecturer
		{
			get { return this._Lecturer; }
		}

		/// <summary>
		/// Pobiera lokalizację zajęć.
		/// </summary>
		public FinalLocation Location
		{
			get { return this._Location; }
		}

		/// <summary>
		/// Pobiera notatki.
		/// </summary>
		public string Notes
		{
			get { return this._Notes; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		/// <param name="shortName"></param>
		/// <param name="longName"></param>
		/// <param name="lecturer"></param>
		/// <param name="location"></param>
		/// <param name="notes"></param>
		public FinalClasses(
			LocalDateTime startDate, LocalDateTime endDate,
			string shortName, string longName,
			FinalLecturer lecturer, FinalLocation location,
			string notes)
		{
			this._StartDate = startDate;
			this._EndDate = endDate;
			this._ShortName = shortName;
			this._LongName = longName;
			this._Lecturer = lecturer;
			this._Location = location;
			this._Notes = notes;
		}
	}
}
