using NodaTime;

namespace StudentsCalendar.Core.Intermediates
{
	/// <summary>
	/// Zajęcia/wykład - dane pośredniczące.
	/// </summary>
	public sealed class IntermediateClasses
	{
		/// <summary>
		/// Pobiera lub zmienia datę rozpoczęcia zajęć.
		/// </summary>
		/// <remarks>
		/// Nie jest sprawdzane, czy <see cref="StartDate"/> &lt; <see cref="EndDate"/>.
		/// </remarks>
		public LocalDateTime StartDate { get; set; }

		/// <summary>
		/// Pobiera lub zmienia datę zakończenia zajęć.
		/// </summary>
		public LocalDateTime EndDate { get; set; }

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
		public IntermediateLecturer Lecturer { get; set; }

		/// <summary>
		/// Pobiera lub zmienia lokalizację.
		/// </summary>
		public IntermediateLocation Location { get; set; }

		/// <summary>
		/// Pobiera lub zmienia notatki.
		/// </summary>
		public string Notes { get; set; }
	}
}
