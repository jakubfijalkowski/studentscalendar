using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Odwołuje zajęcia.
	/// </summary>
	public sealed class CancelClasses
		: IClassesModifier
	{
		/// <inheritdoc />
		public IActivitySpan ActivitySpan { get; set; }

		/// <inheritdoc />
		public IntermediateClasses Apply(IntermediateClasses data, GenerationContext context)
		{
			return null;
		}
	}
}
