using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class DateRangeActivitySpanViewModel
		: BaseActivitySpanViewModel<DateRangeActivitySpan>
	{
		public DateRangeActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}

	public sealed class EmptyActivitySpanViewModel
		: BaseActivitySpanViewModel<EmptyActivitySpan>
	{
		public EmptyActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}

	public sealed class EveryXMonthsActivitySpanViewModel
		: BaseActivitySpanViewModel<EveryXMonthsActivitySpan>
	{
		public EveryXMonthsActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}

	public sealed class EveryXWeeksActivitySpanViewModel
		: BaseActivitySpanViewModel<EveryXWeeksActivitySpan>
	{
		public EveryXWeeksActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}

	public sealed class FullActivitySpanViewModel
		: BaseActivitySpanViewModel<FullActivitySpan>
	{
		public FullActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
