namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Szablon lokalizacji wykładu.
	/// </summary>
	public sealed class LocationTemplate
	{
		/// <summary>
		/// Pobiera lub zmienia nazwę budynku(np. nazwa wydziału).
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Pobiera lub zmienia adres budynku.
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// Pobiera lub zmienia salę zajęciową.
		/// </summary>
		public string Room { get; set; }
	}
}
