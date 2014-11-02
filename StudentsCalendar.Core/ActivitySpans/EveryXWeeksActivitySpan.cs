using System;
using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który pozwala na wykonanie się danej akcji
	/// tylko co kilka tygodni.
	/// </summary>
	public sealed class EveryXWeeksActivitySpan
		: IActivitySpan, IWeekActivitySpan
	{
		private int _Count = 1;

		/// <summary>
		/// Pobiera lub zmienia liczbę tygodni.
		/// </summary>
		public int Count
		{
			get { return this._Count; }
			set { this._Count = Math.Max(1, value); }
		}

		/// <inheritdoc />
		public bool IsActive(LocalDate baseDate, LocalDate date)
		{
			var distance = Period.Between(baseDate, date, PeriodUnits.Weeks);
			return (distance.Weeks % this.Count) == 0;
		}

		/// <inheritdoc />
		public bool IsWeekActive(LocalDate baseDate, LocalDate date)
		{
			return this.IsActive(baseDate, date);
		}
	}
}
