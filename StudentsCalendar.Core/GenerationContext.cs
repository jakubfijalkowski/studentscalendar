using NodaTime;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Kontekst procesu generowania kalendarza.
	/// </summary>
	public sealed class GenerationContext
	{
		private readonly IClassesGenerator _ClassesGenerator;
		private readonly IDayGenerator _DayGenerator;
		private readonly IWeekGenerator _WeekGenerator;
		private readonly ICalendarGenerator _CalendarGenerator;

		private readonly LocalDate _StartDate;
		private readonly LocalDate _EndDate;

		/// <summary>
		/// Pobiera generator zajęć używany w aktualnym procesie.
		/// </summary>
		public IClassesGenerator ClassesGenerator
		{
			get { return this._ClassesGenerator; }
		}

		/// <summary>
		/// Pobiera generator dni używany w aktualnym procesie.
		/// </summary>
		public IDayGenerator DayGenerator
		{
			get { return this._DayGenerator; }
		}

		/// <summary>
		/// Pobiera generator tygodni używany w aktualnym procesie.
		/// </summary>
		public IWeekGenerator WeekGenerator
		{
			get { return this._WeekGenerator; }
		}

		/// <summary>
		/// Pobiera generator kalendarza, używany w aktualnym procesie.
		/// </summary>
		public ICalendarGenerator CalendarGenerator
		{
			get { return this._CalendarGenerator; }
		}

		/// <summary>
		/// Pobiera datę rozpoczęcia aktywności kalendarza.
		/// </summary>
		/// <remarks>
		/// Data zawsze wskazuje na poniedziałek, nawet jeśli kalendarz nie zaczyna się
		/// w poniedziałek. Obcięcie następuje po zakończeniu procesu generowania.
		/// Od tej daty można liczyć "daty bazowe" dla poszczególnych dni tygodnia.
		/// </remarks>
		public LocalDate StartDate
		{
			get { return this._StartDate; }
		}

		/// <summary>
		/// Pobiera datę zakończenia kalendarza.
		/// </summary>
		/// <remarks>
		/// Zawsze wskazuje na niedzielę, nawet jeśli kalendarz kończy się wcześniej.
		/// Obcięcie następuje po zakończeniu procesu generowania.
		/// </remarks>
		public LocalDate EndDate
		{
			get { return this._EndDate; }
		}

		/// <summary>
		/// Inicjalizuje kontekst wszystkimi zależnościami.
		/// </summary>
		/// <param name="classesGenerator"></param>
		/// <param name="dayGenerator"></param>
		/// <param name="weekGenerator"></param>
		/// <param name="calendarGenerator"></param>
		public GenerationContext(IClassesGenerator classesGenerator, IDayGenerator dayGenerator,
			IWeekGenerator weekGenerator, ICalendarGenerator calendarGenerator,
			LocalDate startDate, LocalDate endDate)
		{
			this._ClassesGenerator = classesGenerator;
			this._DayGenerator = dayGenerator;
			this._WeekGenerator = weekGenerator;
			this._CalendarGenerator = calendarGenerator;
			this._StartDate = startDate;
			this._EndDate = endDate;
		}
	}
}
