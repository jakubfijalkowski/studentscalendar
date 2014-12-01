namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Odwraca aktywność dowolnego <see cref="IWeeklyActivitySpan"/>.
	/// </summary>
	public sealed class InverseWeeklyActivitySpan
		: IWeeklyActivitySpan
	{
		/// <summary>
		/// Bazowy <see cref="IWeeklyActivitySpan"/>.
		/// </summary>
		public IWeeklyActivitySpan Span { get; set; }

		public InverseWeeklyActivitySpan()
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
