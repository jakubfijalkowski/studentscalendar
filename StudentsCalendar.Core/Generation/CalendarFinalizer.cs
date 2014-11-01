using System.Collections.Generic;
using System.Linq;
using StudentsCalendar.Core.Finals;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Domyślna implementacja finalizera.
	/// </summary>
	public sealed class CalendarFinalizer
		: ICalendarFinalizer
	{
		/// <inheritdoc />
		public FinalCalendar Finalize(IntermediateCalendar calendar)
		{
			return new FinalCalendar(
					startDate: calendar.StartDate,
					endDate: calendar.EndDate,
					weeks: Finalize(calendar.Weeks)
				);
		}

		private static IReadOnlyList<FinalWeek> Finalize(IEnumerable<IntermediateWeek> weeks)
		{
			return weeks.Select(Finalize).ToArray();
		}

		private static FinalWeek Finalize(IntermediateWeek week)
		{
			return new FinalWeek(
					date: week.Date,
					days: Finalize(week.Days)
				);
		}

		private static IReadOnlyList<FinalDay> Finalize(IEnumerable<IntermediateDay> days)
		{
			return days.Select(Finalize).ToArray();
		}

		private static FinalDay Finalize(IntermediateDay day)
		{
			return new FinalDay(
					date: day.Date,
					classes: Finalize(day.Classes),
					notes: day.Notes
				);
		}

		private static IReadOnlyList<FinalClasses> Finalize(IEnumerable<IntermediateClasses> classes)
		{
			return classes.Select(Finalize).ToArray();
		}

		private static FinalClasses Finalize(IntermediateClasses classes)
		{
			return new FinalClasses(
					startDate: classes.StartDate,
					endDate: classes.EndDate,
					shortName: classes.ShortName,
					fullName: classes.FullName,
					lecturer: Finalize(classes.Lecturer),
					location: Finalize(classes.Location),
					notes: classes.Notes
				);
		}

		private static FinalLecturer Finalize(IntermediateLecturer lecturer)
		{
			return new FinalLecturer(
					firstName: lecturer.FirstName,
					lastName: lecturer.LastName,
					phoneNumber: lecturer.PhoneNumber
				);
		}

		private static FinalLocation Finalize(IntermediateLocation location)
		{
			return new FinalLocation(
					name: location.Name,
					address: location.Address,
					room: location.Room
				);
		}
	}
}
