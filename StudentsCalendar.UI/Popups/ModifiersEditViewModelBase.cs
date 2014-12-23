using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
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

	public abstract class ModifiersEditViewModelBase<TData, TModifier>
		: PopupBaseViewModel<bool>, IViewModel
		where TData : class
		where TModifier : IModifier
	{
		protected readonly IShell Shell;
		protected readonly IModifierRenderer ModifierRenderer;
		protected readonly IActivitySpanRenderer ActivitySpanRenderer;
		protected readonly IDataProvider DataProvider;

		private EditableObject<TData> EditableData;
		private ObservableCollection<ModifierDescription> _Modifiers;

		/// <summary>
		/// Pobiera lub zmienia obiekt, które chcemy edytować.
		/// </summary>
		public TData Data
		{
			get { return this.EditableData != null ? this.EditableData.Data : null; }
			set
			{
				if (this.EditableData == null || this.EditableData.Data != value)
				{
					this.EditableData = new EditableObject<TData>(value);
					this.OnDataChanged();
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
		/// Pobiera listę dostępnych modyfikatorów.
		/// </summary>
		public abstract IReadOnlyList<BaseDescription<TModifier>> AvailableModifiers { get; }

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="shell"></param>
		/// <param name="modifierRenderer"></param>
		/// <param name="activitySpanRenderer"></param>
		/// <param name="dataProvider"></param>
		public ModifiersEditViewModelBase(IShell shell, IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer, IDataProvider dataProvider)
		{
			this.Shell = shell;
			this.ModifierRenderer = modifierRenderer;
			this.ActivitySpanRenderer = activitySpanRenderer;
			this.DataProvider = dataProvider;
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
			this.EditableData.Rollback();
			this.Close(false);
		}

		/// <summary>
		/// Tworzy nowy modyfikator i wyświetla listę 
		/// </summary>
		/// <param name="desc"></param>
		public async void AddModifier(ClassesModifierDescription desc)
		{
			var mod = this.DataProvider.Create(desc);

			if (await this.Shell.ShowModifierEditPopup(mod).CloseTask)
			{
				var description = new ModifierDescription(mod)
				{
					Description = this.ModifierRenderer.Describe(mod),
					SpanDescription = this.ActivitySpanRenderer.Describe(mod.ActivitySpan)
				};
				this.DataModifiers.Add((TModifier)mod);
				this._Modifiers.Add(description);
			}
		}

		/// <summary>
		/// Wyświetla okno edycji modyfikatora.
		/// </summary>
		/// <param name="desc"></param>
		public async void EditModifier(ModifierDescription desc)
		{
			if (await this.Shell.ShowModifierEditPopup(desc.Modifier).CloseTask)
			{
				desc.Description = this.ModifierRenderer.Describe(desc.Modifier);
				desc.SpanDescription = this.ActivitySpanRenderer.Describe(this.ExtractActivitySpan((TModifier)desc.Modifier));
			}
		}

		/// <summary>
		/// Usuwa modyfikator.
		/// </summary>
		/// <param name="desc"></param>
		public void DeleteModifier(ModifierDescription desc)
		{
			this.DataModifiers.Remove((TModifier)desc.Modifier);
			this._Modifiers.Remove(desc);
		}

		/// <summary>
		/// Pobiera listę modyfikatorów aktualnie zawartych w danych na których pracuje ViewModel.
		/// </summary>
		protected abstract IList<TModifier> DataModifiers { get; }

		/// <summary>
		/// Pobiera <see cref="IActivitySpan"/> z danego modyfikatora.
		/// </summary>
		/// <param name="modifier"></param>
		/// <returns></returns>
		protected abstract IActivitySpan ExtractActivitySpan(TModifier modifier);

		protected virtual void OnDataChanged()
		{
			var modifiers = from m in this.DataModifiers
							let mod = this.ModifierRenderer.Describe(m)
							let span = this.ExtractActivitySpan(m)
							let spanDesc = this.ActivitySpanRenderer.Describe(span)
							select new ModifierDescription(m) { Description = mod, SpanDescription = spanDesc };

			this._Modifiers = new ObservableCollection<ModifierDescription>(modifiers);

			this.NotifyOfPropertyChange(() => this.Data);
			this.NotifyOfPropertyChange(() => this.Modifiers);
		}
	}
}
