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
		/// Wczytuje listę kalendarzy.
		/// </summary>
		/// <returns></returns>
		Task<Stream> LoadEntries();

		/// <summary>
		/// Wczytuje konkretny szablon kalendarza.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Stream> LoadCalendar(string id);
	}
}
