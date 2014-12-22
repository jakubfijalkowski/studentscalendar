using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class SpecificWeeksActivitySpanViewModel
		: BaseActivitySpanViewModel<SpecificWeeksActivitySpan>
	{
		public SpecificWeeksActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
