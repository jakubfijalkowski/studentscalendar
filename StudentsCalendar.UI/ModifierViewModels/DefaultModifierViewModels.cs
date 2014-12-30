using StudentsCalendar.Core.Modifiers;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ModifierViewModels
{
	public sealed class AddTestToClassesViewModel
		: BaseModifierViewModel<AddTestToClasses>
	{
		public AddTestToClassesViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Dodaj test";
		}
	}

	public sealed class CancelClassesViewModel
		: BaseModifierViewModel<CancelClasses>
	{
		public CancelClassesViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Odwołaj zajęcia";
		}
	}

	public sealed class CancelClassesInRangeViewModel
		: BaseModifierViewModel<CancelClassesInRange>
	{
		public CancelClassesInRangeViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Odwołaj zajęcia";
		}
	}

	public sealed class CancelDayViewModel
		: BaseModifierViewModel<CancelDay>
	{
		public CancelDayViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Odwołaj zajęcia w całym dniu";
		}
	}

	public sealed class CancelWeekViewModel
		: BaseModifierViewModel<CancelWeek>
	{
		public CancelWeekViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Odwołaj zajęcia w całym tygodniu";
		}
	}

	public sealed class ChangeWeekdayViewModel
		: BaseModifierViewModel<ChangeWeekday>
	{
		public ChangeWeekdayViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Zamień dzień tygodnia";
		}
	}

	public sealed class AddBreaksViewModel
		: BaseModifierViewModel<AddBreaks>
	{
		public AddBreaksViewModel(IDataProvider dataProvider, IActivitySpanEditor editor)
			: base(dataProvider, editor)
		{
			this.DisplayName = "Dodaj przerwy";
		}

	}
}
