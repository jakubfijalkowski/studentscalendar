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
		/// Inicjalizuje kontekst wszystkimi zależnościami.
		/// </summary>
		/// <param name="classesGenerator"></param>
		/// <param name="dayGenerator"></param>
		/// <param name="weekGenerator"></param>
		/// <param name="calendarGenerator"></param>
		public GenerationContext(IClassesGenerator classesGenerator, IDayGenerator dayGenerator,
			IWeekGenerator weekGenerator, ICalendarGenerator calendarGenerator)
		{
			this._ClassesGenerator = classesGenerator;
			this._DayGenerator = dayGenerator;
			this._WeekGenerator = weekGenerator;
			this._CalendarGenerator = calendarGenerator;
		}
	}
}
