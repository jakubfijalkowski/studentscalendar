using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Storage;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Menedżer odpowiedzialny za dostęp do listy kalendarzy, aktualnie wybranego kalendarza
	/// oraz jego wygenerowanej reprezentacji.
	/// </summary>
	/// <remarks>
	/// Zakłada się, że dostęp do właściwości jest możliwy z każdego wątku, zaś wywołania
	/// metod powinny być robione tylko na jednym wątku w danym czasie(czyli nie można
	/// wywołać metody z innego wątku, jeśli dowolna metoda jest w trakcie wykonywania).
	/// Dostęp nie jest nadzorowany.
	/// </remarks>
	public interface ICalendarsManager
	{
		/// <summary>
		/// Pobiera listę kalendarzy.
		/// </summary>
		IReadOnlyList<CalendarEntry> Entries { get; }

		/// <summary>
		/// Pobiera aktualnie aktywny wpis kalendarza.
		/// </summary>
		CalendarEntry ActiveEntry { get; }

		/// <summary>
		/// Pobiera wygenerowaną reprezentacje aktualnie wygenerowanego kalendarza.
		/// </summary>
		FinalCalendar ActiveCalendar { get; }

		/// <summary>
		/// Pobiera wynik procesu generowania, z którego powstał <see cref="ActiveCalendar"/>.
		/// </summary>
		GenerationResults GenerationResults { get; }

		/// <summary>
		/// Asynchronicznie inicjalizuje menadżer. Powinno być wywoływane tylko raz,
		/// na początku działania aplikacji.
		/// </summary>
		/// <exception cref="InvalidOperationException">Rzucane, gdy menedżer został już zainicjalizowany.</exception>
		/// <returns></returns>
		Task Initialize();
	}
}
