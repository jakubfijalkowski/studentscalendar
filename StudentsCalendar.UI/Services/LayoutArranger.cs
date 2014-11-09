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
		public ArrangedDay Arrange(FinalDay day)
		{
			var startTime = DateHelper.Min(day.Classes.First().StartDate.TimeOfDay, MinStartTime);
			var endTime = DateHelper.Max(day.Classes.Last().EndDate.TimeOfDay, MinEndTime);
			return ArrangeDay(day, startTime, endTime);
		}

		/// <inheritdoc />
		public ArrangedWeek Arrange(FinalWeek week)
		{
			var startTime = DateHelper.Min(week.Days.Select(d => d.Classes.First()).Min(c => c.StartDate.TimeOfDay), MinStartTime);
			var endTime = DateHelper.Max(week.Days.Select(d => d.Classes.Last()).Max(c => c.EndDate.TimeOfDay), MinEndTime);
			return new ArrangedWeek(week, week.Days.Select(d => ArrangeDay(d, startTime, endTime)).ToArray());
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
