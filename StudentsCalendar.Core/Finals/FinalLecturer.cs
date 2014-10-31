namespace StudentsCalendar.Core.Finals
{
	/// <summary>
	/// Opis wykładowcy.
	/// </summary>
	public sealed class FinalLecturer
	{
		private readonly string _FirstName;
		private readonly string _LastName;
		private readonly string _PhoneNumber;

		/// <summary>
		/// Pobiera imię wykładowcy.
		/// </summary>
		public string FirstName
		{
			get { return this._FirstName; }
		}

		/// <summary>
		/// Pobiera nazwisko wykładowcy
		/// </summary>
		public string LastName
		{
			get { return this._LastName; }
		}

		/// <summary>
		/// Pobiera numer telefonu wykładowcy.
		/// </summary>
		public string PhoneNumber
		{
			get { return this._PhoneNumber; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		public FinalLecturer(string firstName, string lastName, string phoneNumber)
		{
			this._FirstName = firstName;
			this._LastName = lastName;
			this._PhoneNumber = phoneNumber;
		}
	}
}
