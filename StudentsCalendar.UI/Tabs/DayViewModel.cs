using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Tabs
{
	/// <summary>
	/// ViewModel karty widoku dnia.
	/// </summary>
	public sealed class DayViewModel
		: Screen, IMainTab
	{
		private readonly ICalendarEngine CalendarEngine;
		private readonly ILayoutArranger LayoutArranger;
		private readonly IContentProvider ContentProvider;

		private ArrangedDay _DayLayout;

		/// <inheritdoc />
		public int Priority
		{
			get { return 0; }
		}

		/// <summary>
		/// Pobiera ułożony layout dzienny.
		/// </summary>
		public ArrangedDay DayLayout
		{
			get { return this._DayLayout; }
			set
			{
				this._DayLayout = value;
				this.NotifyOfPropertyChange();
			}
		}


		/// <summary>
		/// Inicjalizuje obiekt.
		/// </summary>
		public DayViewModel(ICalendarEngine calendarEngine, ILayoutArranger layoutArranger, IContentProvider content)
		{
			this.CalendarEngine = calendarEngine;
			this.LayoutArranger = layoutArranger;
			this.ContentProvider = content;

			this.DisplayName = "Dzień";
		}

		protected override async void OnInitialize()
		{
			base.OnInitialize();

			var calendar = (await this.ContentProvider.LoadCalendars()).First(c => c.IsActive);
			var generated = await Task.Run(() => this.CalendarEngine.Generate(calendar.Template));
			var day = generated.Calendar.Weeks.SelectMany(w => w.Days).First(d => d.Date >= DateHelper.Today && d.Date.IsoDayOfWeek == NodaTime.IsoDayOfWeek.Wednesday);
			this.DayLayout = this.LayoutArranger.Arrange(day);
		}
	}
}
