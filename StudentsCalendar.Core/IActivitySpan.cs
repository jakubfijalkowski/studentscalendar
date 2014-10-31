using NodaTime;

namespace StudentsCalendar.Core
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

	/// <summary>
	/// Definicja tygodniowego przedziału aktywności.
	/// </summary>
	public interface IWeekActivitySpan
		: IActivitySpan
	{
		/// <summary>
		/// Sprawdza, czy dany tydzień jest aktywny.
		/// </summary>
		/// <param name="date">Tydzień(reprezentowany przez poniedziałek, który należy sprawdzić.</param>
		/// <returns></returns>
		bool IsWeekActive(LocalDate date);
	}
}
