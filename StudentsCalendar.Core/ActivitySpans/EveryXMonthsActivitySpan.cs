using System;
using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który pozwala na wykonanie się danej akcji
	/// tylko co kilka miesięcy.
	/// </summary>
	public sealed class EveryXMonthsActivitySpan
		: IActivitySpan, IWeekActivitySpan
	{
		private int _Count = 1;

		/// <summary>
		/// Pobiera lub zmienia liczbę miesięcy.
		/// </summary>
		public int Count
		{
			get { return this._Count; }
			set { this._Count = Math.Max(1, value); }
		}

		/// <summary>
		/// Data rozpoczęcia aktywności - określa dzień, od kiedy dany przedział jest aktywny.
		/// </summary>
		public LocalDate? StartDate { get; set; }

		/// <inheritdoc />
		public bool IsActive(LocalDate baseDate, LocalDate date)
		{
			var distance = Period.Between(this.StartDate ?? baseDate, date, PeriodUnits.Months);
			return distance.Months >= 0 && (distance.Months % this.Count) == 0;
		}

		/// <inheritdoc />
		public bool IsWeekActive(LocalDate baseDate, LocalDate date)
		{
			return this.IsActive(baseDate, date);
		}
	}
}
