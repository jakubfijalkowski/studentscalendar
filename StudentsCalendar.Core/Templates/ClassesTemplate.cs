using System;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon zajęć/wykładu.
	/// </summary>
	public sealed class ClassesTemplate
	{
		/// <summary>
		/// Pobiera lub zmienia godzinę rozpoczęcia zajęć.
		/// </summary>
		/// <remarks>
		/// Nie jest sprawdzane, czy <see cref="StartTime"/> &lt; <see cref="EndTime"/>.
		/// </remarks>
		public DateTime StartTime { get; set; }

		/// <summary>
		/// Pobiera lub zmienia godzinę zakończenia zajęć.
		/// </summary>
		public DateTime EndTime { get; set; }

		/// <summary>
		/// Pobiera lub zmienia krótki opis zajęć.
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia pełny opis zajęć.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia prowadzącego.
		/// </summary>
		public LecturerTemplate Lecturer { get; set; }

		/// <summary>
		/// Pobiera lub zmienia lokalizację.
		/// </summary>
		public LocationTemplate Location { get; set; }

		/// <summary>
		/// Pobiera lub zmienia notatki.
		/// </summary>
		public string Notes { get; set; }
	}
}
