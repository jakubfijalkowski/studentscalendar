namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Odwraca aktywność dowolnego <see cref="IDailyActivitySpan"/>.
	/// </summary>
	public sealed class InverseActivitySpan
		: IDailyActivitySpan
	{
		/// <summary>
		/// Bazowy <see cref="IDailyActivitySpan"/>.
		/// </summary>
		public IDailyActivitySpan Span { get; set; }

		public InverseActivitySpan()
		{
			this.Span = new EmptyActivitySpan();
		}
		
		/// <inheritdocs />
		public bool IsActive(NodaTime.LocalDate baseDate, NodaTime.LocalDate date)
		{
			return !this.Span.IsActive(baseDate, date);
		}
	}
}
