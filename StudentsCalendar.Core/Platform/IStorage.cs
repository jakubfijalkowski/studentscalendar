using System.IO;
using System.Threading.Tasks;

namespace StudentsCalendar.Core.Platform
{
	/// <summary>
	/// Abstrakcja platformy uruchomieniowej - dostęp do danych aplikacji.
	/// </summary>
	public interface IStorage
	{
		/// <summary>
		/// Otwiera strumień tylko do odczytu do istniejącego elementu.
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy nie udało się uzyskać dostępu do strumienia.</exception>
		/// <param name="entryId"></param>
		/// <returns></returns>
		Task<Stream> OpenRead(string entryId);
		
		/// <summary>
		/// Otwiera strumień tylko do odczytu do elementu o wskazanym id. Jeśli element nie istnieje,
		/// tworzy go i dopiero otwiera strumień.
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy nie udało się uzyskać dostępu do strumienia.</exception>
		/// <param name="entryId"></param>
		/// <returns></returns>
		Task<Stream> OpenOrCreate(string entryId);

		/// <summary>
		/// Otwiera strumień tylko do zapisu do wskazanego elementu. Jeśli element nie istnieje,
		/// tworzy go.
		/// </summary>
		/// <exception cref="IOException">Rzucane, gdy nie udało się uzyskać dostępu do strumienia.</exception>
		/// <param name="entryId"></param>
		/// <returns></returns>
		Task<Stream> OpenWrite(string entryId);

		/// <summary>
		/// Usuwa wpis. Jeśli wpis nie istnieje to nic nie robi.
		/// </summary>
		/// <param name="entryId"></param>
		void DeleteEntry(string entryId);
	}
}
