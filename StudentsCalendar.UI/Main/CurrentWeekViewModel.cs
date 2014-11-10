using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// Tygodniowy rozkład zajęć
	/// </summary>
	public sealed class CurrentWeekViewModel
		: Screen, IMainScreen
	{
		private readonly IContentProvider ContentProvider;
		private readonly IGenerationEngine CalendarEngine;
		private readonly ILayoutArranger LayoutArranger;

		private ArrangedWeek Week;

		/// <summary>
		/// Pobiera ułożony plan tygodniowy.
		/// </summary>
		public IReadOnlyList<ArrangedDay> Days
		{
			get
			{
				return this.Week != null ? this.Week.Days : null;
			}
		}

		/// <summary>
		/// Pobiera plan aktualnego dnia.
		/// </summary>
		public ArrangedDay Today { get; private set; }

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="contentProvider"></param>
		/// <param name="calendarEngine"></param>
		/// <param name="layoutArranger"></param>
		public CurrentWeekViewModel(IContentProvider contentProvider, IGenerationEngine calendarEngine, ILayoutArranger layoutArranger)
		{
			this.ContentProvider = contentProvider;
			this.CalendarEngine = calendarEngine;
			this.LayoutArranger = layoutArranger;
		}

		protected override async void OnInitialize()
		{
			base.OnInitialize();

			var generated = await LoadCalendar();
			var today = DateHelper.Today;
			var thisWeek = today.IsoDayOfWeek != IsoDayOfWeek.Monday ? today.Previous(IsoDayOfWeek.Monday) : today;
			var week = generated.Weeks.First(w => w.Date == thisWeek);
			this.Week = this.LayoutArranger.Arrange(week);
			this.Today = this.Week.Days.First(d => d.Day.Date == today);

			this.NotifyOfPropertyChange(() => Days);
			this.NotifyOfPropertyChange(() => Today);
		}

		private async Task<FinalCalendar> LoadCalendar()
		{
			var entry = (await this.ContentProvider.LoadCalendars()).First(c => c.IsActive);
			var template = await this.ContentProvider.LoadTemplate(entry.Id);
			return (await Task.Run(() => this.CalendarEngine.Generate(template))).Calendar;
		}
	}
}
