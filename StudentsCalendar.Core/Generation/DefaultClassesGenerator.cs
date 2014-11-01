using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core.Generation
{
	/// <summary>
	/// Domyślna implementacja generatora zajęć. Spełnia podstawowe założenia,
	/// nie robi nic ponadto.
	/// </summary>
	public sealed class DefaultClassesGenerator
		: IClassesGenerator
	{
		/// <inheritdoc />
		public IntermediateClasses Generate(LocalDate classesDate, ClassesTemplate template, GenerationContext context)
		{
			var intermediate = new IntermediateClasses
			{
				StartDate = classesDate.At(template.StartTime),
				EndDate = classesDate.At(template.EndTime),
				ShortName = template.ShortName,
				FullName = template.FullName,
				Notes = template.Notes,
				Lecturer = new IntermediateLecturer
				{
					FirstName = template.Lecturer.FirstName,
					LastName = template.Lecturer.LastName,
					PhoneNumber = template.Lecturer.LastName
				},
				Location = new IntermediateLocation
				{
					Name = template.Location.Name,
					Address = template.Location.Address,
					Room = template.Location.Room
				}
			};
			var baseDate = intermediate.CalculateBaseDateWith(context);
			foreach (var mod in template.Modifiers)
			{
				if (mod.ActivitySpan.IsActive(baseDate, classesDate))
				{
					intermediate = mod.Apply(intermediate, context);
					if (intermediate == null)
					{
						return null;
					}
				}
			}
			return intermediate;
		}
	}
}
