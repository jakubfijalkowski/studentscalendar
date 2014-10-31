using NodaTime;
using StudentsCalendar.Core.Intermediates;
using StudentsCalendar.Core.Templates;

namespace StudentsCalendar.Core
{
	/// <summary>
	/// Domyślna implementacja generatora zajęć. Spełnia podstawowe założenia,
	/// nie robi nic ponadto.
	/// </summary>
	public sealed class DefaultClassesGenerator
		: IClassesGenerator
	{
		/// <inheritdoc />
		public IntermediateClasses Generate(LocalDate date, ClassesTemplate template, GenerationContext context)
		{
			var intermediate = new IntermediateClasses
			{
				StartDate = date.At(template.StartTime),
				EndDate = date.At(template.EndTime),
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
			foreach (var mod in template.Modifiers)
			{
				if (mod.ActivitySpan.IsActive(date))
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
