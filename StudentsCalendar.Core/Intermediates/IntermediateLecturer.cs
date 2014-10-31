namespace StudentsCalendar.Core.Intermediates
{
	/// <summary>
	/// Prowadzący - dane pośredniczące.
	/// </summary>
	public sealed class IntermediateLecturer
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
