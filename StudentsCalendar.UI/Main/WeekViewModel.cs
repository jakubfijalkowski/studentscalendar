using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Storage;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// Widok miesiąca podzielonego na tygodnie. Pozwala na wyświetlenie aktualnego tygodnia i kilku poprzednich/następnych.
	/// </summary>
	public sealed class MonthViewModel
		: Screen, IMainScreen
	{
		private const int MaxWeeks = 2;

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
		public MonthViewModel(IContentProvider contentProvider, ICalendarEngine calendarEngine, ILayoutArranger layoutArranger)
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

			var weekIndex = generated.Weeks.Select((w, i) => Tuple.Create(w, i)).First(w => w.Item1.Date == thisWeek).Item2;

			int startWeekIndex = Math.Max(weekIndex - MaxWeeks, 0);
			int endWeekIndex = Math.Min(weekIndex + MaxWeeks + 1, generated.Weeks.Count - 1);

			this.Weeks = generated.Weeks
				.Skip(startWeekIndex)
				.Take(endWeekIndex - startWeekIndex)
				.Select(this.LayoutArranger.Arrange)
				.ToArray();
			this.CurrentWeek = this.Weeks[weekIndex - startWeekIndex];

			this.NotifyOfPropertyChange(() => CurrentWeek);
			this.NotifyOfPropertyChange(() => Weeks);
		}

		private async Task<FinalCalendar> LoadCalendar()
		{
			var entry = (await this.ContentProvider.LoadCalendars()).First(c => c.IsActive);
			var template = await this.ContentProvider.LoadTemplate(entry.Id);
			return (await Task.Run(() => this.CalendarEngine.Generate(template))).Calendar;
		}
	}
}
