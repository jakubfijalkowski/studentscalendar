using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.UI.Services;

namespace StudentsCalendar.UI.Main
{
	/// <summary>
	/// Tygodniowy rozkład zajęć. Wyświetla odpowiednio zaaranżowane dni(pon - nd) z
	/// aktualnego tygodnia.
	/// </summary>
	public sealed class CurrentWeekViewModel
		: Screen, IViewModel
	{
		private readonly ICurrentCalendar CurrentCalendar;
		private readonly ILayoutArranger LayoutArranger;

		private ArrangedWeek Week;

		/// <summary>
		/// Wskazuje, czy aktualnie wybrany kalendarz jest prawidłowy i da się wyświetlić zawartość tego ViewModelu.
		/// </summary>
		public bool IsDataValid { get; private set; }

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
		/// <param name="calendar"></param>
		/// <param name="layoutArranger"></param>
		public CurrentWeekViewModel(ICurrentCalendar calendar, ILayoutArranger layoutArranger)
		{
			this.DisplayName = "Widok tygodnia";

			this.CurrentCalendar = calendar;
			this.LayoutArranger = layoutArranger;
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();

			FinalWeek currentWeek = null;

			var today = DateHelper.Today;

			if (this.CurrentCalendar.Calendar != null)
			{
				var thisWeek = today.IsoDayOfWeek != IsoDayOfWeek.Monday ? today.Previous(IsoDayOfWeek.Monday) : today;
				currentWeek = this.CurrentCalendar.Calendar.Weeks.FirstOrDefault(w => w.Date == thisWeek);
			}

			this.IsDataValid = currentWeek != null;
			if (this.IsDataValid)
			{
				this.Week = this.LayoutArranger.Arrange(currentWeek);
				this.Today = this.Week.Days.First(d => d.Day.Date == today);
			}

			this.Refresh();
		}
	}
}
