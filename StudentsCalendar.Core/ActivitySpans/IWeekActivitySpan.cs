using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Definicja tygodniowego przedziału aktywności.
	/// </summary>
	public interface IWeekActivitySpan
	{
		/// <summary>
		/// Sprawdza, czy dany tydzień jest aktywny.
		/// </summary>
		/// <param name="date">Tydzień(reprezentowany przez poniedziałek, który należy sprawdzić.</param>
		/// <returns></returns>
		bool IsWeekActive(LocalDate date);
	}
}
