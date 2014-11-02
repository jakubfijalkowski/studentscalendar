using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Odwołuje zajęcia w całym tygodniu.
	/// </summary>
	public sealed class CancelWeek
		: IWeekModifier
	{
		/// <inheritdoc />
		public IWeekActivitySpan ActivitySpan { get; set; }

		/// <inheritdoc />
		public IntermediateWeek Apply(IntermediateWeek data, GenerationContext context)
		{
			foreach (var day in data.Days)
			{
				day.Classes.Clear();
			}
			return data;
		}
	}
}
