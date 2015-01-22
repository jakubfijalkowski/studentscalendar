using System;
using System.Collections.Generic;
using System.Linq;
using NodaTime;
using StudentsCalendar.Core;
using StudentsCalendar.Core.Finals;

namespace StudentsCalendar.UI.Services
{
	/// <summary>
	/// Domyślna implementacja.
	/// </summary>
	sealed class LayoutArranger
		: ILayoutArranger
	{
		private static readonly LocalTime MinStartTime = new LocalTime(8, 0);
		private static readonly LocalTime MinEndTime = new LocalTime(16, 0);

		/// <inheritdoc />
		public ArrangedDay Arrange(FinalDay day, FinalWeek fromWeek)
		{
			var time = CalculateStartAndEndTime(fromWeek);
			return ArrangeDay(day, time.Item1, time.Item2);
		}

		/// <inheritdoc />
		public ArrangedWeek Arrange(FinalWeek week)
		{
			var time = CalculateStartAndEndTime(week);
			return new ArrangedWeek(week, week.Days.Select(d => ArrangeDay(d, time.Item1, time.Item2)).ToArray());
		}

		private static Tuple<LocalTime, LocalTime> CalculateStartAndEndTime(FinalWeek week)
		{
			var startClasses = week.Days.Select(d => d.Classes.FirstOrDefault()).Where(d => d != null);
			var endClasses = week.Days.Select(d => d.Classes.LastOrDefault()).Where(d => d != null);
			var startTime = startClasses.Any() ? DateHelper.Min(startClasses.Min(c => c.StartDate.TimeOfDay), MinStartTime) : MinStartTime;
			var endTime = endClasses.Any() ? DateHelper.Max(endClasses.Max(c => c.EndDate.TimeOfDay), MinEndTime) : MinEndTime;

			startTime = new LocalTime(startTime.Hour, 0);
			endTime = new LocalTime(endTime.Hour, 0);

			return Tuple.Create(startTime, endTime);
		}

		private static ArrangedDay ArrangeDay(FinalDay day, LocalTime startTime, LocalTime endTime)
		{
			var slots = GenerateSlots(startTime, endTime);
			var columns = DivideClasses(day).Select(c => ArrangeColumn(c, startTime)).ToArray();
			return new ArrangedDay(day, slots, columns);
		}

		private static List<List<FinalClasses>> DivideClasses(FinalDay day)
		{
			var columns = new List<List<FinalClasses>>();

			foreach (var classes in day.Classes)
			{
				int currentColumn = 0;
				while (currentColumn < columns.Count && columns[currentColumn].Last().EndDate > classes.StartDate)
				{
					++currentColumn;
				}
				if (columns.Count == currentColumn)
				{
					columns.Add(new List<FinalClasses>());
				}
				columns[currentColumn].Add(classes);
			}

			return columns;
		}

		private static IReadOnlyList<ArrangedClasses> ArrangeColumn(List<FinalClasses> classes, LocalTime startTime)
		{
			return classes.Select(c => new ArrangedClasses(c, TimeToSlot(startTime, c.StartDate), TimeToSlot(startTime, c.EndDate))).ToArray();
		}

		private static IReadOnlyList<LocalTime> GenerateSlots(LocalTime startTime, LocalTime endTime)
		{
			var between = Period.Between(startTime, endTime);
			return Enumerable.Range(0, (int)between.Hours).Select(t => new LocalTime(startTime.Hour + t, 0)).ToArray();
		}

		private static double TimeToSlot(LocalTime baseTime, LocalDateTime date)
		{
			var between = Period.Between(baseTime, date.TimeOfDay);
			return (int)between.Hours + between.Minutes / 60.0;
		}
	}
}
