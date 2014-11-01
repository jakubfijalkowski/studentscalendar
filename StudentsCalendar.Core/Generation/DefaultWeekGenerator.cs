using System.Linq;
using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Domyślny generator opisu tygodnia. Spełnia podstawowe założenia,
	/// nie wykonuje dodatkowych operacji.
	/// </summary>
	public sealed class DefaultWeekGenerator
		: IWeekGenerator
	{
		/// <inheritdoc />
		public IntermediateWeek Generate(LocalDate weekDate, WeekTemplate template, GenerationContext context)
		{
			var intermediate = new IntermediateWeek(weekDate)
			{
				Days = template.Days.Select(d => context.DayGenerator.Generate(weekDate.PlusDays(d.DayOfWeek.ToIndex()), d, context)).ToArray()
			};
			var baseDate = intermediate.CalculateBaseDateWith(context);
			foreach (var modifier in template.Modifiers)
			{
				if (modifier.ActivitySpan.IsWeekActive(baseDate, weekDate))
				{
					intermediate = modifier.Apply(intermediate, context);
				}
			}
			return intermediate;
		}
	}
}
