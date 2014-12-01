using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Opis dla modyfikatorów.
	/// </summary>
	public sealed class ModifierDescription
		: PropertyChangedBase
	{
		private readonly IModifier _Modifier;
		private string _Description;
		private string _SpanDescription;

		/// <summary>
		/// Pobiera modyfikator, którego dotyczy dany obiekt.
		/// </summary>
		public IModifier Modifier
		{
			get { return this._Modifier; }
		}

		/// <summary>
		/// Pobiera opis modyfikatora.
		/// </summary>
		public string Description
		{
			get { return this._Description; }
			set
			{
				if (this._Description != value)
				{
					this._Description = value;
					this.NotifyOfPropertyChange();
				}
			}
		}

		/// <summary>
		/// Pobiera opis przedziału aktywności.
		/// </summary>
		public string SpanDescription
		{
			get { return this._SpanDescription; }
			set
			{
				if (this._SpanDescription != value)
				{
					this._SpanDescription = value;
					this.NotifyOfPropertyChange();
				}
			}
		}

		/// <summary>
		/// Inicjalizuje klasę odpowiednim modyfikatorem.
		/// </summary>
		/// <param name="modifier"></param>
		public ModifierDescription(IModifier modifier)
		{
			this._Modifier = modifier;
		}
	}

	/// <summary>
	/// ViewModel dla ekranu edycji zajęć.
	/// </summary>
	public sealed class ClassesEditViewModel
		: Screen, IViewModel
	{
		private readonly IModifierRenderer ModifierRenderer;
		private readonly IActivitySpanRenderer ActivitySpanRenderer;

		private readonly TaskCompletionSource<bool> CloseTCS = new TaskCompletionSource<bool>();

		private EditableObject<ClassesTemplate> EditableClasses;
		private ObservableCollection<ModifierDescription> _Modifiers;

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
					this.OnClassesChanged();
				}
			}
		}

		/// <summary>
		/// Pobiera kolekcję modyfikatorów
		/// </summary>
		public IReadOnlyList<ModifierDescription> Modifiers
		{
			get
			{
				return this._Modifiers;
			}
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="modifierRenderer"></param>
		/// <param name="activitySpanRenderer"></param>
		public ClassesEditViewModel(IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer)
		{
			this.ModifierRenderer = modifierRenderer;
			this.ActivitySpanRenderer = activitySpanRenderer;
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

		/// <summary>
		/// Tworzy nowy modyfikator i wyświetla listę 
		/// </summary>
		/// <param name="desc"></param>
		public void AddModifier(ModifierDescription desc)
		{

		}

		/// <summary>
		/// Wyświetla okno edycji modyfikatora.
		/// </summary>
		/// <param name="desc"></param>
		public void EditModifier(ModifierDescription desc)
		{

		}

		/// <summary>
		/// Usuwa modyfikator.
		/// </summary>
		/// <param name="desc"></param>
		public void DeleteModifier(ModifierDescription desc)
		{
			this.Classes.Modifiers.Remove((IClassesModifier)desc.Modifier);
			this._Modifiers.Remove(desc);
		}

		private void Close(bool result)
		{
			this.CloseTCS.SetResult(result);
			this.TryClose();
		}

		private void OnClassesChanged()
		{
			var modifiers = from m in this.Classes.Modifiers
							let mod = this.ModifierRenderer.Describe(m)
							let span = this.ActivitySpanRenderer.Describe(m.ActivitySpan)
							select new ModifierDescription(m) { Description = mod, SpanDescription = span };

			this._Modifiers = new ObservableCollection<ModifierDescription>(modifiers);

			this.NotifyOfPropertyChange(() => this.Classes);
			this.NotifyOfPropertyChange(() => this.Modifiers);
		}
	}
}
