using System.Collections.Generic;
using NodaTime;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class SpecificDatesActivitySpanViewModel
		: BaseDatesSpanViewModel<SpecificDatesActivitySpan>
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

		public SpecificDatesActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }
	}
}
