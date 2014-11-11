namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Odwraca aktywność dowolnego <see cref="IWeekActivitySpan"/>.
	/// </summary>
	public sealed class InverseWeekActivitySpan
		: IWeekActivitySpan
	{
		/// <summary>
		/// Bazowy <see cref="IWeekActivitySpan"/>.
		/// </summary>
		public IWeekActivitySpan Span { get; set; }

		public InverseWeekActivitySpan()
		{
			this.Span = new EmptyActivitySpan();
		}
		
		/// <inheritdocs />
		public bool IsWeekActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return !this.Span.IsWeekActive(baseDate, date);
		}
	}
}
