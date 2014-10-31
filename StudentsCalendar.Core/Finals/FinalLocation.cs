namespace StudentsCalendar.Core.Finals
{
	/// <summary>
	/// Lokalizacja zajęć.
	/// </summary>
	public sealed class FinalLocation
	{
		private readonly string _Name;
		private readonly string _Address;
		private readonly string _Room;

		/// <summary>
		/// Pobiera nazwę budynku.
		/// </summary>
		public string Name
		{
			get { return this._Name; }
		}

		/// <summary>
		/// Pobiera adres budynku
		/// </summary>
		public string Address
		{
			get { return this._Address; }
		}

		/// <summary>
		/// Pobiera sale zajęciową.
		/// </summary>
		public string Room
		{
			get { return this._Room; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="address"></param>
		/// <param name="room"></param>
		public FinalLocation(string name, string address, string room)
		{
			this._Name = name;
			this._Address = address;
			this._Room = room;
		}
	}
}
