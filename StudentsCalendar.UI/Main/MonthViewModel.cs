using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// Widok miesiąca podzielonego na tygodnie. Pozwala na wyświetlenie aktualnego tygodnia i kilku poprzednich/następnych.
	/// </summary>
	public sealed class MonthViewModel
		: Screen, IViewModel
	{
		private const int MaxWeeks = 2;

		private readonly ICurrentCalendar CurrentCalendar;
		private readonly ILayoutArranger LayoutArranger;

		/// <summary>
		/// Wskazuje, czy aktualnie wybrany kalendarz jest prawidłowy i da się wyświetlić zawartość tego ViewModelu.
		/// </summary>
		public bool IsDataValid { get; private set; }

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
		/// <param name="calendar"></param>
		/// <param name="layoutArranger"></param>
		public MonthViewModel(ICurrentCalendar calendar, ILayoutArranger layoutArranger)
		{
			this.DisplayName = "Widok miesiąca";

			this.CurrentCalendar = calendar;
			this.LayoutArranger = layoutArranger;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			this.IsDataValid = true;
			do
			{
				if (this.CurrentCalendar == null)
				{
					this.IsDataValid = false;
					break;
				}

				var generated = this.CurrentCalendar.Calendar;

				var today = DateHelper.Today;
				var thisWeek = today.IsoDayOfWeek != IsoDayOfWeek.Monday ? today.Previous(IsoDayOfWeek.Monday) : today;

				var currentWeek = generated.Weeks
					.Select((w, i) => new { Week = w, Index = i })
					.FirstOrDefault(w => w.Week.Date == thisWeek);

				if (currentWeek == null)
				{
					this.IsDataValid = false;
					break;
				}

				var weekIndex = currentWeek.Index;

				int startWeekIndex = Math.Max(weekIndex - MaxWeeks, 0);
				int endWeekIndex = Math.Min(weekIndex + MaxWeeks + 1, generated.Weeks.Count - 1);

				this.Weeks = generated.Weeks
					.Skip(startWeekIndex)
					.Take(endWeekIndex - startWeekIndex)
					.Select(this.LayoutArranger.Arrange)
					.ToArray();
				this.CurrentWeek = this.Weeks[weekIndex - startWeekIndex];

			} while (false);

			this.Refresh();
		}
	}
}
