using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Definicja dziennego przedziału aktywności.
	/// </summary>
	public interface IActivitySpan
	{
		/// <summary>
		/// Sprawdza, czy dana data jest aktywna w ramach przedziału aktywności.
		/// </summary>
		/// <param name="date">Dzień, który należy sprawdzić.</param>
		/// <returns></returns>
		bool IsActive(LocalDate date);
	}
}
