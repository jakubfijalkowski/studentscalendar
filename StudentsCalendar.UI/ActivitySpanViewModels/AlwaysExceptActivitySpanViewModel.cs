using System.Collections.Generic;
using NodaTime;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class AlwaysExceptActivitySpanViewModel
		: BaseDatesSpanViewModel<AlwaysExceptActivitySpan>
	{
		protected override IList<LocalDate> InternalDates
		{
			get
			{
				return this.Span.Dates;
			}
			set
			{
				this.Span.Dates = value;
			}
		}

		public AlwaysExceptActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
