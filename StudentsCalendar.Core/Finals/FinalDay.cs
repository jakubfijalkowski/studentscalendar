using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.Finals
{
	/// <summary>
	/// Opis dnia.
	/// </summary>
	public sealed class FinalDay
	{
		private readonly LocalDate _Date;
		private readonly IReadOnlyList<FinalClasses> _Classes;
		private readonly string _Notes;

		/// <summary>
		/// Pobiera dzień, który dany obiekt opisuje.
		/// </summary>
		public LocalDate Date
		{
			get { return this._Date; }
		}

		/// <summary>
		/// Pobiera listę zajęć danego dnia.
		/// </summary>
		/// <remarks>
		/// Lista jest posortowana po godzinie rozpoczęcia zajęć.
		/// </remarks>
		public IReadOnlyList<FinalClasses> Classes
		{
			get { return this._Classes; }
		}

		/// <summary>
		/// Pobiera notatki przypisane do danego dnia.
		/// </summary>
		public string Notes
		{
			get { return this._Notes; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="date"></param>
		/// <param name="classes"></param>
		/// <param name="notes"></param>
		public FinalDay(LocalDate date, IReadOnlyList<FinalClasses> classes, string notes)
		{
			this._Date = date;
			this._Classes = classes;
			this._Notes = notes;
		}
	}
}
