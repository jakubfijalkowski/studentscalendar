using System.Collections.Generic;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Lista modyfikatorów dla pojedynczego dnia.
	/// </summary>
	public sealed class DayModifiersEditViewModel
		: ModifiersEditViewModelBase<DayTemplate, IDayModifier>
	{
		public override IReadOnlyList<BaseDescription<IDayModifier>> AvailableModifiers
		{
			get { return this.DataProvider.DayModifiers; }
		}

		protected override IList<IDayModifier> DataModifiers
		{
			get { return this.Data.Modifiers; }
		}

		protected override IActivitySpan ExtractActivitySpan(IDayModifier modifier)
		{
			return modifier.ActivitySpan;
		}

		public DayModifiersEditViewModel(IShell shell, IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer, IDataProvider dataProvider)
			: base(shell, modifierRenderer, activitySpanRenderer, dataProvider)
		{
			this.DisplayName = "Edycja modyfikatorów dziennych";
		}
	}
}
