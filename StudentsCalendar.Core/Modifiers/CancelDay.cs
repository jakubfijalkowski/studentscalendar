using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Odwołuje zajęcia danego dnia.
	/// </summary>
	public sealed class CancelDay
		: IDayModifier
	{
		/// <inheritdoc />
		public IActivitySpan ActivitySpan { get; set; }

		/// <inheritdoc />
		public IntermediateDay Apply(IntermediateDay data, GenerationContext context)
		{
			data.Classes.Clear();
			return data;
		}
	}
}
