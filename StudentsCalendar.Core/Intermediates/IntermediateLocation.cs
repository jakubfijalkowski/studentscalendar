namespace StudentsCalendar.Core.Intermediates
{
	/// <summary>
	/// Lokalizacja zajęć - dane pośredniczące.
	/// </summary>
	public sealed class IntermediateLocation
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
