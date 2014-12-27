using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.ActivitySpanViewModels
{
	public sealed class EveryXMonthsActivitySpanViewModel
		: BaseActivitySpanViewModel<EveryXMonthsActivitySpan>
	{
		private bool _HasStartDate;

		public bool HasStartDate
		{
			get { return this._HasStartDate; }
			set
			{
				if (this._HasStartDate != value)
				{
					this._HasStartDate = value;
					this.NotifyOfPropertyChange();
				}
			}
		}

		public override void Save()
		{
			if (!this.HasStartDate)
			{
				this.Span.StartDate = null;
			}
		}

		public EveryXMonthsActivitySpanViewModel(IActivitySpanRenderer renderer)
			: base(renderer)
		{ }

		protected override void OnSpanChanged()
		{
			base.OnSpanChanged();

			this.HasStartDate = this.Span.StartDate.HasValue;
		}
	}
}
