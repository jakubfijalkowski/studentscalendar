using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.UI.ModifierViewModels
{
	/// <summary>
	/// Bazowy interfejs dla ViewModeli odpowiedzialnych za edycję modyfikatorów.
	/// Nie powinien być implementowany ręcznie - używany tylko do uproszczenia kodu.
	/// </summary>
	public interface IModifierViewModel
		: IViewModel
	{
		/// <summary>
		/// Pobiera lub zmienia edytowany modyfikator.
		/// </summary>
		IModifier Modifier { get; set; }
	}

	/// <summary>
	/// Bazowa klasa dla ViewModeli odpowiedzialnych za edycję poszczególnych modyfikatorów.
	/// </summary>
	/// <typeparam name="TModifier"></typeparam>
	public abstract class BaseModifierViewModel<TModifier>
		: Popups.PopupBaseViewModel<bool>, IModifierViewModel
		where TModifier : class, IModifier
	{
		private EditableObject<TModifier> EditableObject;

		/// <summary>
		/// Pobiera lub zmienia edytowany modyfikator.
		/// </summary>
		public TModifier Modifier
		{
			get { return this.EditableObject != null ? this.EditableObject.Data : null; }
			set
			{
				if (this.EditableObject == null || this.EditableObject.Data != value)
				{
					this.EditableObject = new EditableObject<TModifier>(value);
					this.OnModifierChanged();
				}
			}
		}
		
		/// <inheritdoc />
		IModifier IModifierViewModel.Modifier
		{
			get { return this.Modifier; }
			set { this.Modifier = (TModifier)value; }
		}

		/// <summary>
		/// Zapisuje zmiany i zamyka okno edycji.
		/// </summary>
		public virtual void Save()
		{
			this.Close(true);
		}

		/// <summary>
		/// Anuluje zmiany i zamyka okno edycji.
		/// </summary>
		public virtual void Cancel()
		{
			this.EditableObject.Rollback();
			this.Close(false);
		}

		/// <summary>
		/// Wywoływana, gdy zmieni się <see cref="Modifier"/>.
		/// </summary>
		protected virtual void OnModifierChanged()
		{
			this.NotifyOfPropertyChange(() => this.Modifier);
		}
	}
}
