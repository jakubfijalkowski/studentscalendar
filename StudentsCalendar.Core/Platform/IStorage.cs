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
		/// Wczytuje źróło kalendarza.
		/// </summary>
		/// <returns></returns>
		Task<Stream> LoadCalendars();
	}
}
