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
		public IntermediateWeek Generate(LocalDate baseDate, WeekTemplate template, GenerationContext context)
		{
			var intermediate = new IntermediateWeek(baseDate)
			{
				Days = template.Days.Select(d => context.DayGenerator.Generate(baseDate.PlusDays(d.DayOfWeek.ToIndex()), d, context)).ToArray()
			};
			foreach (var modifier in template.Modifiers)
			{
				if (modifier.ActivitySpan.IsWeekActive(baseDate))
				{
					intermediate = modifier.Apply(intermediate, context);
				}
			}
			return intermediate;
		}
	}
}
