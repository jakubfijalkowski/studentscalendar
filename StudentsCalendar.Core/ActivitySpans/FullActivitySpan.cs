using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Przedział aktywności, który dla dowolnej daty jest aktywny.
	/// </summary>
	public sealed class FullActivitySpan
		: IActivitySpan, IWeekActivitySpan
	{
		/// <inheritdoc />
		public bool IsActive(LocalDate date)
		{
			return true;
		}

		/// <inheritdoc />
		public bool IsWeekActive(LocalDate date)
		{
			return true;
		}
	}
}
