using System.Collections.Generic;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.Core.Templates;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Popups
{
	/// <summary>
	/// Lista modyfikatorów dla szablonu kalendarza.
	/// </summary>
	public sealed class CalendarModifiersEditViewModel
		: ModifiersEditViewModelBase<CalendarTemplate, ICalendarModifier>
	{
		public override IReadOnlyList<BaseDescription<ICalendarModifier>> AvailableModifiers
		{
			get { return this.DataProvider.CalendarModifiers; }
		}

		protected override IList<ICalendarModifier> DataModifiers
		{
			get { return this.Data.Modifiers; }
		}

		protected override IActivitySpan ExtractActivitySpan(ICalendarModifier modifier)
		{
			return new FullActivitySpan();
		}

		public CalendarModifiersEditViewModel(IShell shell, IModifierRenderer modifierRenderer, IActivitySpanRenderer activitySpanRenderer, IDataProvider dataProvider)
			: base(shell, modifierRenderer, activitySpanRenderer, dataProvider)
		{ }
	}
}
