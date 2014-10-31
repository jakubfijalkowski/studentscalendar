using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.Finals
{
	/// <summary>
	/// Opis tygodnia.
	/// </summary>
	public sealed class FinalWeek
	{
		private readonly LocalDate _Date;
		private readonly IReadOnlyList<FinalDay> _Days;

		/// <summary>
		/// Pobiera datę tygodnia, który dany obiekt opisuje.
		/// </summary>
		/// <remarks>
		/// Data wskazuje na poniedziałek w danym tygodniu.
		/// </remarks>
		public LocalDate Date
		{
			get { return this._Date; }
		}

		/// <summary>
		/// Pobiera listę opisów poszczególnych dni.
		/// </summary>
		/// <remarks>
		/// Zawiera 7 elementów, odpowiadających każdemu z dni tygodnia.
		/// Jeśli tydzień nie jest pełny(pierwszy/ostatni tydzień), dni są reprezentowane przez puste
		/// obiekty, lecz ciągle jest ich 7.
		/// </remarks>
		public IReadOnlyList<FinalDay> Days
		{
			get { return this._Days; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="date"></param>
		/// <param name="days"></param>
		public FinalWeek(LocalDate date, IReadOnlyList<FinalDay> days)
		{
			this._Date = date;
			this._Days = days;
		}
	}
}
