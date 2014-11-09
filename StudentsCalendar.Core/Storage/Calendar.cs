using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Storage
{
	/// <summary>
	/// Opisuje kalendarz w takiej postaci postaci, w jakiej jest na dysku.
	/// </summary>
	public sealed class Calendar
	{
		/// <summary>
		/// Pobiera lub zmienia nazwę kalendarza.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Pobiera lub zmienia szablon kalendarza.
		/// </summary>
		public CalendarTemplate Template { get; set; }

		/// <summary>
		/// Wskazuje, czy dany kalendarz jest aktualnie aktywny.
		/// </summary>
		/// <remarks>
		/// Tylko jeden kalendarz może być aktywny.
		/// </remarks>
		public bool IsActive { get; set; }
	}
}
