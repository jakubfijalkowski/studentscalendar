using System.Linq;
using NodaTime;
using StudentsCalendar.Core.Generation;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Domyślna implementacja silnika kalendarza.
	/// </summary>
	public class CalendarEngine
		: ICalendarEngine
	{
		private readonly ICalendarGenerator CalendarGenerator;
		private readonly IWeekGenerator WeekGenerator;
		private readonly IDayGenerator DayGenerator;
		private readonly IClassesGenerator ClassesGenerator;
		private readonly ICalendarFinalizer CalendarFinalizer;

		/// <summary>
		/// Inicjalizuje obiekt niezbędnymi właściwościami.
		/// </summary>
		/// <param name="calendarGenerator"></param>
		/// <param name="weekGenerator"></param>
		/// <param name="dayGenerator"></param>
		/// <param name="classesGenerator"></param>
		/// <param name="calendarFinalizer"></param>
		public CalendarEngine(ICalendarGenerator calendarGenerator, IWeekGenerator weekGenerator,
			IDayGenerator dayGenerator, IClassesGenerator classesGenerator,
			ICalendarFinalizer calendarFinalizer)
		{
			this.CalendarGenerator = calendarGenerator;
			this.WeekGenerator = weekGenerator;
			this.DayGenerator = dayGenerator;
			this.ClassesGenerator = classesGenerator;
			this.CalendarFinalizer = calendarFinalizer;
		}

		/// <inheritdoc />
		public GenerationResults Generate(CalendarTemplate template)
		{
			var context = this.CreateContext(template);
			var calendar = this.CalendarGenerator.Generate(template, context);
			TrimExcess(template, calendar);
			SortClasses(calendar);
			// TODO: add validation
			var final = this.CalendarFinalizer.Finalize(calendar);
			return new GenerationResults(final);
		}

		private GenerationContext CreateContext(CalendarTemplate template)
		{
			LocalDate startDate = template.StartDate;
			LocalDate endDate = template.EndDate;
			if (startDate.IsoDayOfWeek != IsoDayOfWeek.Monday)
			{
				startDate = startDate.Previous(IsoDayOfWeek.Monday);
			}
			if (endDate.IsoDayOfWeek != IsoDayOfWeek.Sunday)
			{
				endDate = endDate.Next(IsoDayOfWeek.Sunday);
			}

			return new GenerationContext(
				this.ClassesGenerator, this.DayGenerator,
				this.WeekGenerator, this.CalendarGenerator,
				template, startDate, endDate);
		}

		private static void TrimExcess(CalendarTemplate template, IntermediateCalendar calendar)
		{
			var firstWeek = calendar.Weeks.First();
			var lastWeek = calendar.Weeks.Last();

			var pre = firstWeek.Days.TakeWhile(d => d.Date < template.StartDate);
			var post = lastWeek.Days.SkipWhile(d => d.Date <= template.EndDate);
			foreach (var day in pre.Concat(post))
			{
				day.Classes.Clear();
				day.Notes = string.Empty;
			}
		}

		private static void SortClasses(IntermediateCalendar calendar)
		{
			foreach (var day in calendar.Weeks.SelectMany(d => d.Days))
			{
				day.Classes.Sort((a, b) => a.StartDate.CompareTo(b.StartDate));
			}
		}
	}
}
