using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// Ogólny widok tygodnia. Pozwala na wyświetlenie aktualnego tygodnia i kilku poprzednich/następnych.
	/// </summary>
	public sealed class WeekViewModel
		: Screen, IMainScreen
	{
		private const int MaxWeeks = 3;

		private readonly IContentProvider ContentProvider;
		private readonly ICalendarEngine CalendarEngine;
		private readonly ILayoutArranger LayoutArranger;

		/// <summary>
		/// Pobiera listę tygodni załadowanych do ViewModelu.
		/// </summary>
		public IReadOnlyList<ArrangedWeek> Weeks { get; private set; }

		/// <summary>
		/// Pobiera aktualny tydzień.
		/// </summary>
		public ArrangedWeek CurrentWeek { get; private set; }

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi zależnościami.
		/// </summary>
		/// <param name="contentProvider"></param>
		/// <param name="calendarEngine"></param>
		/// <param name="layoutArranger"></param>
		public WeekViewModel(IContentProvider contentProvider, ICalendarEngine calendarEngine, ILayoutArranger layoutArranger)
		{
			this.ContentProvider = contentProvider;
			this.CalendarEngine = calendarEngine;
			this.LayoutArranger = layoutArranger;
		}

		protected override async void OnInitialize()
		{
			base.OnInitialize();

			var calendar = (await this.ContentProvider.LoadCalendars()).First(c => c.IsActive);
			var generated = await Task.Run(() => this.CalendarEngine.Generate(calendar.Template));
			var today = DateHelper.Today;
			var thisWeek = today.IsoDayOfWeek != IsoDayOfWeek.Monday ? today.Previous(IsoDayOfWeek.Monday) : today;

			var weekIndex = generated.Calendar.Weeks.Select((w, i) => Tuple.Create(w, i)).First(w => w.Item1.Date == thisWeek).Item2;

			int startWeekIndex = Math.Max(weekIndex - MaxWeeks, 0);
			int endWeekIndex = Math.Min(weekIndex + MaxWeeks + 1, generated.Calendar.Weeks.Count - 1);

			this.Weeks = generated.Calendar.Weeks
				.Skip(startWeekIndex)
				.Take(endWeekIndex - startWeekIndex)
				.Select(this.LayoutArranger.Arrange)
				.ToArray();
			this.CurrentWeek = this.Weeks[weekIndex - startWeekIndex];

			this.NotifyOfPropertyChange(() => CurrentWeek);
			this.NotifyOfPropertyChange(() => Weeks);
		}
	}
}
