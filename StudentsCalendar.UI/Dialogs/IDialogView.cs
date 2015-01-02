using System.Threading.Tasks;

namespace StudentsCalendar.UI.Dialogs
{
	/// <summary>
	/// "Marker interface" dla widoków klas dialogów.
	/// </summary>
	public interface IDialogView
	{
		/// <summary>
		/// Czeka, aż okno dialogowe zostanie zamknięte.
		/// </summary>
		/// <returns><see cref="Task"/>, którego należy "zawaitować", by poczekać na zamknięcie.</returns>
		Task WaitForClose();
	}
}
