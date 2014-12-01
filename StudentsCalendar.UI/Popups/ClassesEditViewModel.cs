using System.Threading.Tasks;
using Caliburn.Micro;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// ViewModel dla ekranu edycji zajęć.
	/// </summary>
	public sealed class ClassesEditViewModel
		: Screen, IViewModel
	{
		private readonly TaskCompletionSource<bool> CloseTCS = new TaskCompletionSource<bool>();

		private EditableObject<ClassesTemplate> EditableClasses;

		/// <summary>
		/// Pobiera lub zmienia zajęcia, które chcemy edytować.
		/// </summary>
		public ClassesTemplate Classes
		{
			get { return this.EditableClasses != null ? this.EditableClasses.Data : null; }
			set
			{
				if (this.EditableClasses == null || this.EditableClasses.Data != value)
				{
					this.EditableClasses = new EditableObject<ClassesTemplate>(value);
					this.NotifyOfPropertyChange();
				}
			}
		}

		/// <summary>
		/// Czeka na zakończenie edycji. Zwraca wartość wskazującą, czy dane zostały
		/// zapisane czy odrzucone.
		/// </summary>
		/// <returns></returns>
		public Task<bool> WaitForClose()
		{
			return this.CloseTCS.Task;
		}

		/// <summary>
		/// Zapisuje zmiany i zamyka okno.
		/// </summary>
		public void Save()
		{
			this.Close(true);
		}

		/// <summary>
		/// Anuluje zmiany i zamyka okno.
		/// </summary>
		public void Cancel()
		{
			this.EditableClasses.Rollback();
			this.Close(false);
		}

		private void Close(bool result)
		{
			this.CloseTCS.SetResult(result);
			this.TryClose();
		}
	}
}
