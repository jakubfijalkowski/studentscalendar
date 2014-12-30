using System.Collections.Generic;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// ViewModel dla ekranu edycji zajęć.
	/// </summary>
	public sealed class ClassesEditViewModel
		: ModifiersEditViewModelBase<ClassesTemplate, IClassesModifier>, IViewModel
	{
		/// <inheritdoc />
		public override IReadOnlyList<BaseDescription<IClassesModifier>> AvailableModifiers
		{
			get { return this.DataProvider.ClassesModifiers; }
		}

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="shell"></param>
		/// <param name="modifierRenderer"></param>
		/// <param name="activitySpanRenderer"></param>
		/// <param name="dataProvider"></param>
		public ClassesEditViewModel(IShell shell, IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer, IDataProvider dataProvider)
			: base(shell, modifierRenderer, activitySpanRenderer, dataProvider)
		{
			this.DisplayName = "Edycja zajęć";
		}

		/// <inheritdoc />
		protected override IList<IClassesModifier> DataModifiers
		{
			get { return this.Data.Modifiers; }
		}

		/// <inheritdoc />
		protected override Core.ActivitySpans.IActivitySpan ExtractActivitySpan(IClassesModifier modifier)
		{
			return modifier.ActivitySpan;
		}
	}
}
