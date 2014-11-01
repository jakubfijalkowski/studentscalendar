using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Definicja tygodniowego przedziału aktywności.
	/// </summary>
	/// <remarks>
	/// Więcej informacji na temat pracy przedziału aktywności znajduje się w
	/// dokumentacji <see cref="IActivitySpan"/>.
	/// </remarks>
	/// <seealso cref="IActivitySpan"/>
	public interface IWeekActivitySpan
	{
		/// <summary>
		/// Sprawdza, czy dany tydzień jest aktywny.
		/// </summary>
		/// <param name="baseDate">Data bazowa.</param>
		/// <param name="date">Tydzień(reprezentowany przez poniedziałek, który należy sprawdzić).</param>
		/// <returns></returns>
		bool IsWeekActive(LocalDate baseDate, LocalDate date);
	}
}
