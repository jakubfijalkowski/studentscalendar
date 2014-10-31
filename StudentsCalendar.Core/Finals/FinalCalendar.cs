using System.Collections.Generic;
using NodaTime;

namespace StudentsCalendar.Core.Finals
{
	/// <summary>
	/// Kalendarz.
	/// </summary>
	public sealed class FinalCalendar
	{
		private readonly IReadOnlyList<FinalWeek> _Weeks;
		private readonly LocalDate _StartDate;
		private readonly LocalDate _EndDate;

		/// <summary>
		/// Pobiera listę opisów tygodni dla całej aktywności kalendarza.
		/// </summary>
		public IReadOnlyList<FinalWeek> Weeks
		{
			get { return this._Weeks; }
		}

		/// <summary>
		/// Pobiera początkową datę aktywności kalendarza.
		/// </summary>
		public LocalDate StartDate
		{
			get { return this._StartDate; }
		}

		/// <summary>
		/// Pobiera końcową datę aktywności kalendarza.
		/// </summary>
		public LocalDate EndDate
		{
			get { return this._EndDate; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi danymi.
		/// </summary>
		/// <param name="weeks"></param>
		/// <param name="startDate"></param>
		/// <param name="endDate"></param>
		public FinalCalendar(IReadOnlyList<FinalWeek> weeks, LocalDate startDate, LocalDate endDate)
		{
			this._Weeks = weeks;
			this._StartDate = startDate;
			this._EndDate = endDate;
		}
	}
}
