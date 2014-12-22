using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class SpecificDatesActivitySpanViewModel
		: BaseActivitySpanViewModel<SpecificDatesActivitySpan>
	{
		public SpecificDatesActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
