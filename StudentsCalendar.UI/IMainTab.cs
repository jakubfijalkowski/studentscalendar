using Caliburn.Micro;

namespace StudentsCalendar.UI
{
	/// <summary>
	/// Określa kartę głównego okna.
	/// </summary>
	public interface IMainTab
		: IScreen
	{
		/// <summary>
		/// Określa priorytet karty na ekranie. Po nim będą sortowane.
		/// </summary>
		int Priority { get; }
	}
}
