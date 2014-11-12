using System;
using System.Collections.Generic;
using System.IO;
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
		/// <remarks>
		/// To powinna być kolekcja, która może być "obserwowana"(tj. implementuje
		/// <see cref="System.Collections.Specialized.INotifyCollectionChanged"/>),
		/// np. <see cref="System.Collections.ObjectModel.ObservableCollection"/>.
		/// </remarks>
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
		/// <exception cref="IOException">Rzucane, gdy nie udało się uzyskać dostępu do pliku z kalendarzami.</exception>
		/// <exception cref="CalendarTemplateNotFoundException">Rzucane, gdy nie odnaleziono wpisu</exception>
		/// <returns></returns>
		Task Initialize();

		/// <summary>
		/// Usuwa wpis z listy.
		/// </summary>
		/// <exception cref="InvalidOperationException">Rzucane, gdy podjęto próbę usunięcia aktywnego wpisu.</exception>
		/// <exception cref="IOException">Rzucane, gdy menedżer nie był w stanie zapisać zmian.</exception>
		/// <param name="entry"></param>
		Task DeleteEntry(CalendarEntry entry);

		/// <summary>
		/// Ustawia wskazany element na "aktywny".
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy menedżer nie był w stanie zapisać zmian.</exception>
		/// <exception cref="CalendarTemplateNotFoundException">Rzucane, gdy nie odnaleziono wpisu</exception>
		/// <param name="entry"></param>
		/// <returns></returns>
		Task MakeActive(CalendarEntry entry);
	}
}
