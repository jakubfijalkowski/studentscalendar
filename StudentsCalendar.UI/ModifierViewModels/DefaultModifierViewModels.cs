using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	public sealed class AddTestToClassesViewModel
		: BaseModifierViewModel<AddTestToClasses>
	{
		public AddTestToClassesViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }
	}

	public sealed class CancelClassesViewModel
		: BaseModifierViewModel<CancelClasses>
	{
		public CancelClassesViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }
	}

	public sealed class CancelClassesInRangeViewModel
		: BaseModifierViewModel<CancelClassesInRange>
	{
		public CancelClassesInRangeViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }
	}

	public sealed class CancelDayViewModel
		: BaseModifierViewModel<CancelDay>
	{
		public CancelDayViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }
	}

	public sealed class CancelWeekViewModel
		: BaseModifierViewModel<CancelWeek>
	{
		public CancelWeekViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }
	}

	public sealed class ChangeWeekdayViewModel
		: BaseModifierViewModel<ChangeWeekday>
	{
		public ChangeWeekdayViewModel(IDataProvider dataProvider, IActivitySpanRenderer spanRenderer)
			: base(dataProvider, spanRenderer)
		{ }
	}
}
