using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class AlwaysExceptActivitySpanViewModel
		: BaseActivitySpanViewModel<AlwaysExceptActivitySpan>
	{
		public AlwaysExceptActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
