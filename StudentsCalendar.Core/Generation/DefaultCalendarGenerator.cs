using System.Collections.Generic;
using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Domyślny generator kalendarza. Spełnia podstawowe założenia,
	/// nie robi nic dodatkowego. Nie obcina zajęć kalendarza na początku/końcu
	/// przedziału aktywności. Zostawia to zadanie finalizerowi.
	/// </summary>
	public sealed class DefaultCalendarGenerator
		: ICalendarGenerator
	{
		/// <inheritdoc />
		public IntermediateCalendar Generate(CalendarTemplate template, GenerationContext context)
		{
			var weekCount = (int)Period.Between(template.StartDate, template.EndDate).Weeks;
			var weeks = new List<IntermediateWeek>(weekCount);

			var currentWeek = template.StartDate;
			if (currentWeek.IsoDayOfWeek != IsoDayOfWeek.Monday)
			{
				currentWeek = currentWeek.Previous(IsoDayOfWeek.Monday);
			}

			while (currentWeek <= template.EndDate)
			{
				var intermediateWeek = context.WeekGenerator.Generate(currentWeek, template.WeekTemplate, context);
				weeks.Add(intermediateWeek);
				currentWeek = currentWeek.Next(IsoDayOfWeek.Monday);
			}

			var intermediate = new IntermediateCalendar
			{
				StartDate = template.StartDate,
				EndDate = template.EndDate,
				Weeks = weeks
			};
			foreach (var modifier in template.Modifiers)
			{
				intermediate = modifier.Apply(intermediate, context);
			}
			return intermediate;
		}
	}
}
