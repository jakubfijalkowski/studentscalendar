using System.Collections.Generic;
using System.Linq;
using NodaTime;
using StudentsCalendar.Core.Modifiers;

namespace StudentsCalendar.Core.Templates
{
	/// <summary>
	/// Klasa pomocnicza do generowania pustych kalendarzy(UI).
	/// </summary>
	public static class EmptyCalendar
	{
		/// <summary>
		/// Tworzy pusty kalendarz.
		/// </summary>
		/// <returns></returns>
		public static CalendarTemplate Create()
		{
			return new CalendarTemplate
			{
				WeekTemplate = CreateWeek(),
				StartDate = DateHelper.Today.PlusDays(-1),
				EndDate = DateHelper.Today.PlusDays(1),
				Modifiers = new List<ICalendarModifier>()
			};
		}

		/// <summary>
		/// Tworzy pustą definicję zajęć.
		/// </summary>
		/// <returns></returns>
		public static ClassesTemplate CreateClasses()
		{
			return new ClassesTemplate
			{
				StartTime = DateHelper.Now.TimeOfDay.PlusHours(-1),
				EndTime = DateHelper.Now.TimeOfDay.PlusHours(1),
				ShortName = string.Empty,
				FullName = string.Empty,
				Lecturer = CreateLecturer(),
				Location = CreateLocation(),
				Notes = string.Empty,
				Modifiers = new List<IClassesModifier>()
			};
		}

		private static WeekTemplate CreateWeek()
		{
			return new WeekTemplate
			{
				Days = Enumerable.Range(0, 7).Select(CreateDay).ToArray(),
				Modifiers = new List<IWeekModifier>()
			};
		}

		private static DayTemplate CreateDay(int index)
		{
			return CreateDay(index.ToDayOfWeek());
		}

		private static DayTemplate CreateDay(IsoDayOfWeek dayOfWeek)
		{
			return new DayTemplate(dayOfWeek)
			{
				Classes = new List<ClassesTemplate>(),
				Notes = string.Empty,
				Modifiers = new List<IDayModifier>()
			};
		}

		private static LecturerTemplate CreateLecturer()
		{
			return new LecturerTemplate
			{
				FirstName = string.Empty,
				LastName = string.Empty,
				PhoneNumber = string.Empty
			};
		}

		private static LocationTemplate CreateLocation()
		{
			return new LocationTemplate
			{
				Name = string.Empty,
				Address = string.Empty,
				Room = string.Empty
			};
		}
	}
}
