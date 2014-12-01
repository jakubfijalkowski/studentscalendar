using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który dla dowolnej daty jest nieaktywny.
	/// </summary>
	public sealed class EmptyActivitySpan
		: IDailyActivitySpan, IWeeklyActivitySpan
	{
		/// <inheritdoc />
		public bool IsActive(LocalDate baseDate, LocalDate date)
		{
			return false;
		}

		/// <inheritdoc />
		public bool IsWeekActive(LocalDate baseDate, LocalDate date)
		{
			return false;
		}
	}
}
