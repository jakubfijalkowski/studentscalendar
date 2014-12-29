using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

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
		private readonly IDataProvider DataProvider;
		private readonly IActivitySpanEditor ActivitySpanEditor;

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
					this.OnModifierChangedInternal();
				}
			}
		}

		/// <summary>
		/// Pobiera ViewModel odpowiedzialny za edycję przedziału aktywności.
		/// </summary>
		public ActivitySpanEditViewModel ActivitySpan { get; private set; }

		/// <inheritdoc />
		IModifier IModifierViewModel.Modifier
		{
			get { return this.Modifier; }
			set { this.Modifier = (TModifier)value; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="dataProvider"></param>
		/// <param name="editor"></param>
		public BaseModifierViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
		{
			this.DataProvider = dataProvider;
			this.ActivitySpanEditor = editor;
		}

		/// <summary>
		/// Zapisuje zmiany i zamyka okno edycji.
		/// </summary>
		public virtual void Save()
		{
			if (this.Modifier is IClassesModifier)
			{
				((IClassesModifier)this.Modifier).ActivitySpan = (IDailyActivitySpan)this.ActivitySpan.SelectedSpan.Span;
			}
			else if (this.Modifier is IDayModifier)
			{
				((IDayModifier)this.Modifier).ActivitySpan = (IDailyActivitySpan)this.ActivitySpan.SelectedSpan.Span;
			}
			else if (this.Modifier is IWeekModifier)
			{
				((IWeekModifier)this.Modifier).ActivitySpan = (IWeeklyActivitySpan)this.ActivitySpan.SelectedSpan.Span;
			}

			if (this.ActivitySpan != null)
			{
				this.ActivitySpan.Save();
			}
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

		private void OnModifierChangedInternal()
		{
			if (this.Modifier is IClassesModifier)
			{
				this.ActivitySpan = ActivitySpanEditViewModel.Create(this.DataProvider, this.ActivitySpanEditor, (IClassesModifier)this.Modifier);
			}
			else if (this.Modifier is IDayModifier)
			{
				this.ActivitySpan = ActivitySpanEditViewModel.Create(this.DataProvider, this.ActivitySpanEditor, (IDayModifier)this.Modifier);
			}
			else if (this.Modifier is IWeekModifier)
			{
				this.ActivitySpan = ActivitySpanEditViewModel.Create(this.DataProvider, this.ActivitySpanEditor, (IWeekModifier)this.Modifier);
			}
			else
			{
				this.ActivitySpan = null;
			}

			this.NotifyOfPropertyChange(() => this.ActivitySpan);

			this.OnModifierChanged();
		}
	}
}
