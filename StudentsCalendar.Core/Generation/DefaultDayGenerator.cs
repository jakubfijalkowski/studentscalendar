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
		public IntermediateDay Generate(LocalDate date, DayTemplate template, GenerationContext context)
		{
			var intermediate = new IntermediateDay(date)
			{
				Notes = template.Notes,
				Classes = template.Classes.Select(c => context.ClassesGenerator.Generate(date, c, context)).Where(c => c != null).ToList()
			};
			foreach (var modifier in template.Modifiers)
			{
				if (modifier.ActivitySpan.IsActive(date))
				{
					intermediate = modifier.Apply(intermediate, context);
				}
			}
			return intermediate;
		}
	}
}
