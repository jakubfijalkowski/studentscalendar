using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// Tygodniowy rozkład zajęć
	/// </summary>
	public sealed class CurrentWeekViewModel
		: Screen, IMainScreen
	{
		private readonly ICalendarsManager Calendars;
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
		/// <param name="layoutArranger"></param>
		public CurrentWeekViewModel(ICalendarsManager calendars, ILayoutArranger layoutArranger)
		{
			this.Calendars = calendars;
			this.LayoutArranger = layoutArranger;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			var today = DateHelper.Today;
			var thisWeek = today.IsoDayOfWeek != IsoDayOfWeek.Monday ? today.Previous(IsoDayOfWeek.Monday) : today;
			var week = this.Calendars.ActiveCalendar.Weeks.First(w => w.Date == thisWeek);
			this.Week = this.LayoutArranger.Arrange(week);
			this.Today = this.Week.Days.First(d => d.Day.Date == today);

			this.NotifyOfPropertyChange(() => Days);
			this.NotifyOfPropertyChange(() => Today);
		}
	}
}
