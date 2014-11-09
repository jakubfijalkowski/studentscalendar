using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Tabs
{
	/// <summary>
	/// ViewModel karty widoku tygodnia.
	/// </summary>
	public sealed class WeekViewModel
		: Screen, IMainTab
	{
		private readonly ICalendarEngine CalendarEngine;
		private readonly ILayoutArranger LayoutArranger;
		private readonly IContentProvider ContentProvider;

		private ArrangedWeek _WeekLayout;

		/// <inheritdoc />
		public int Priority
		{
			get { return 1; }
		}

		/// <summary>
		/// Pobiera ułożony layout tygodniowy.
		/// </summary>
		public ArrangedWeek WeekLayout
		{
			get { return this._WeekLayout; }
			set
			{
				this._WeekLayout = value;
				this.NotifyOfPropertyChange();
			}
		}


		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		public WeekViewModel(ICalendarEngine calendarEngine, ILayoutArranger layoutArranger, IContentProvider content)
		{
			this.CalendarEngine = calendarEngine;
			this.LayoutArranger = layoutArranger;
			this.ContentProvider = content;

			this.DisplayName = "Tydzień";
		}

		protected override async void OnInitialize()
		{
			base.OnInitialize();

			var calendar = (await this.ContentProvider.LoadCalendars()).First(c => c.IsActive);
			var generated = await Task.Run(() => this.CalendarEngine.Generate(calendar.Template));
			var thisWeek = DateHelper.Today;
			if (thisWeek.IsoDayOfWeek != NodaTime.IsoDayOfWeek.Monday)
			{
				thisWeek = thisWeek.Previous(NodaTime.IsoDayOfWeek.Monday);
			}
			var week = generated.Calendar.Weeks.First(w => w.Date == thisWeek);
			this.WeekLayout = this.LayoutArranger.Arrange(week);
		}
	}
}
