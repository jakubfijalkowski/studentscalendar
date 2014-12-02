using System.Threading.Tasks;
using Caliburn.Micro;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Klasa bazowa dla ekranów-okien, które muszą mówić, kiedy zostają zamknięte.
	/// </summary>
	/// <typeparam name="TResult"></typeparam>
	public abstract class PopupBaseViewModel<TResult>
		: Screen
	{
		private readonly TaskCompletionSource<TResult> CloseTCS = new TaskCompletionSource<TResult>();

		/// <summary>
		/// Pobiera zadanie, które zostaje oznaczone jako zakończone, gdy
		/// okno zostanie zamknięte
		/// </summary>
		public Task<TResult> CloseTask
		{
			get { return this.CloseTCS.Task; }
		}

		/// <summary>
		/// Zamyka okno.
		/// </summary>
		/// <param name="result"></param>
		protected void Close(TResult result)
		{
			this.CloseTCS.SetResult(result);
			this.TryClose();
		}
	}
}
