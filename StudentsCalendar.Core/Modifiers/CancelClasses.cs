using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Generation;
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
		public IDailyActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public CancelClasses()
		{
			this.ActivitySpan = new EmptyActivitySpan();
		}

		/// <inheritdoc />
		public IntermediateClasses Apply(IntermediateClasses data, GenerationContext context)
		{
			return null;
		}
	}
}
