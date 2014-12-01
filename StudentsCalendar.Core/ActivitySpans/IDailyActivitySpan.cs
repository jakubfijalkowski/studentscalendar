using NodaTime;

namespace StudentsCalendar.Core.ActivitySpans
{
	/// <summary>
	/// Definicja dziennego przedziału aktywności.
	/// </summary>
	/// <remarks>
	/// Przedział aktywności może pracować na dwa sposoby - absolutny i relatywny.
	/// Przez sposób "absolutny" rozumiemy konkretny zakres dat(np. 1 listopada 2014),
	/// w których przedział jest aktywny. Sposób relatywny operuje na odległości
	/// między "datą bazową" a aktualną datą i sprawdza ilość wystapień pewnej
	/// "jednostki czasu"(w rozumieniu NodaTime - np. dnia, tygodnia, miesiąca).
	/// 
	/// Przez "datę bazową" rozumiemy datę pierwszego wystąpienia danego obiektu.
	/// Np. dla tygodnia rozumiemy datę pierwszego tygodnia aktywności kalendarza
	/// (poniedziałek). Dla poszczególnych dni, np. dla środy, datę wystąpienia
	/// pierwszej środy w pierwszym tygodniu.
	/// "Data bazowa" może zostać nadpisana przez użytkownika.
	/// </remarks>
	public interface IDailyActivitySpan
		: IActivitySpan
	{
		/// <summary>
		/// Sprawdza, czy dana data jest aktywna w ramach przedziału aktywności.
		/// </summary>
		/// <param name="baseDate">Data bazowa.</param>
		/// <param name="date">Dzień, który należy sprawdzić.</param>
		/// <returns></returns>
		bool IsActive(LocalDate baseDate, LocalDate date);
	}
}
