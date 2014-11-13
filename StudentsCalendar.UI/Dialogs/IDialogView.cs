using System.Threading.Tasks;

namespace StudentsCalendar.UI.Dialogs
{
	/// <summary>
	/// "Marker interface" dla widoków klas dialogów.
	/// </summary>
	/// <remarks>
	/// <see cref="IShell"/> powinien ustawiać <c>DataContext</c>, jeśli
	/// kontrolka udostępnia taką właściwość.
	/// </remarks>
	public interface IDialogView
	{
		/// <summary>
		/// Czeka, aż okno dialogowe zostanie zamknięte.
		/// </summary>
		/// <returns><see cref="Task"/>, którego należy "zawaitować", by poczekać na zamknięcie.</returns>
		Task WaitForClose();
	}
}
