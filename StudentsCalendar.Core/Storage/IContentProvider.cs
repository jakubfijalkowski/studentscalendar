using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentsCalendar.Core.Storage
{
	/// <summary>
	/// Relatywnie niskopoziomowy interfejs odpowiedzialny za wczytywanie i zapisywanie danych
	/// aplikacji.
	/// </summary>
	public interface IContentProvider
	{
		/// <summary>
		/// Wczytuje i deserializuje dostępne kalendarze.
		/// </summary>
		/// <returns></returns>
		Task<IReadOnlyList<Calendar>> LoadCalendars();
	}
}
