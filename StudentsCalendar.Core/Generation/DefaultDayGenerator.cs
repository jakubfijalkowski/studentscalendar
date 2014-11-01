using System.Linq;
using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Domyślna implementacja generatora dni. Spełnia podstawowe założenia,
	/// nie wykonuje dodatkowych operacji.
	/// </summary>
	public sealed class DefaultDayGenerator
		: IDayGenerator
	{
		/// <inheritdoc />
		public IntermediateDay Generate(LocalDate dayDate, DayTemplate template, GenerationContext context)
		{
			var intermediate = new IntermediateDay(dayDate)
			{
				Notes = template.Notes,
				Classes = template.Classes.Select(c => context.ClassesGenerator.Generate(dayDate, c, context)).Where(c => c != null).ToList()
			};
			var baseDate = intermediate.CalculateBaseDateWith(context);
			foreach (var modifier in template.Modifiers)
			{
				if (modifier.ActivitySpan.IsActive(baseDate, dayDate))
				{
					intermediate = modifier.Apply(intermediate, context);
				}
			}
			return intermediate;
		}
	}
}
