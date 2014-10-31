namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon wykładowcy.
	/// </summary>
	public sealed class LecturerTemplate
	{
		/// <summary>
		/// Pobiera lub zmienia imię wykładowcy.
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nazwisko wykładowcy.
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia numer telefonu.
		/// </summary>
		public string PhoneNumber { get; set; }
	}
}
