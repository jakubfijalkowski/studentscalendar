using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności który jest aktywny tylko w określonym przedziale
	/// dat(przedział domknięty).
	/// </summary>
	/// <remarks>
	/// Tydzień jest aktywny, jeśli zarówno początek jak i koniec tygodnia
	/// jest aktywny.
	/// </remarks>
	public sealed class DateRangeActivitySpan
		: IActivitySpan, IWeekActivitySpan
	{
		private LocalDate _Beginning = DateHelper.Today;
		private LocalDate _End = DateHelper.Today;

		/// <summary>
		/// Pobiera lub zmienia datę początku aktywności.
		/// </summary>
		public LocalDate Beginning
		{
			get { return this._Beginning; }
			set { this._Beginning = value < this.End ? value : this.End; }
		}

		/// <summary>
		/// Pobiera lub zmienia datę końca aktywności.
		/// </summary>
		public LocalDate End
		{
			get { return this._End; }
			set { this._End = value > this.Beginning ? value : this.Beginning; }
		}

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public DateRangeActivitySpan()
		{
			this.Beginning = DateHelper.Today;
			this.End = DateHelper.Today;
		}

		/// <inheritdoc />
		public bool IsActive(LocalDate baseDate, LocalDate date)
		{
			return this.Beginning <= date && date <= this.End;
		}

		/// <inheritdoc />
		public bool IsWeekActive(LocalDate baseDate, LocalDate date)
		{
			return this.IsActive(baseDate, date) &&
				this.IsActive(baseDate, date.Next(IsoDayOfWeek.Sunday));
		}
	}
}
