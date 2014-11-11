namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Odwraca aktywność dowolnego <see cref="IActivitySpan"/>.
	/// </summary>
	public sealed class InverseActivitySpan
		: IActivitySpan
	{
		/// <summary>
		/// Bazowy <see cref="IActivitySpan"/>.
		/// </summary>
		public IActivitySpan Span { get; set; }

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
