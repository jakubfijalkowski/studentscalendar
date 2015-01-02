using System;
using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który jest aktywny tylko co X miesięcy od określonej daty.
	/// </summary>
	/// <remarks>
	/// Klasa ta oblicza odległość między wskazaną datą i datą bazową(opisana w
	/// <see cref="IDailyActivitySpan"/>). Datę bazową można nadpisać przez ustawienie
	/// właściwości <see cref="StartDate"/>.
	/// </remarks>
	public sealed class EveryXMonthsActivitySpan
		: IDailyActivitySpan, IWeeklyActivitySpan
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
