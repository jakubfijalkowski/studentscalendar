using System.Collections.Generic;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Lista modyfikatorów dla szablonu tygodnia.
	/// </summary>
	public sealed class WeekModifiersEditViewModel
		: ModifiersEditViewModelBase<WeekTemplate, IWeekModifier>
	{
		public override IReadOnlyList<BaseDescription<IWeekModifier>> AvailableModifiers
		{
			get { return this.DataProvider.WeekModifiers; }
		}

		protected override IList<IWeekModifier> DataModifiers
		{
			get { return this.Data.Modifiers; }
		}

		protected override IActivitySpan ExtractActivitySpan(IWeekModifier modifier)
		{
			return modifier.ActivitySpan;
		}

		public WeekModifiersEditViewModel(IShell shell, IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer, IDataProvider dataProvider)
			: base(shell, modifierRenderer, activitySpanRenderer, dataProvider)
		{
			this.DisplayName = "Edycja modyfikatorów tygodnia";
		}
	}
}
