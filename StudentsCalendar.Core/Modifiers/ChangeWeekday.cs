using NodaTime;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Podmienia dzień tygodnia na inny. Pozwala na użycie planu z innego dnia tygodnia,
	/// np. "plan poniedziałkowy w piątek".
	/// </summary>
	public sealed class ChangeWeekday
		: IDayModifier
	{
		/// <summary>
		/// Pobiera lub zmienia dzień tygodnia, na który dzień powinien zostać podmieniony.
		/// </summary>
		public IsoDayOfWeek DayOfWeek { get; set; }

		/// <inheritdoc />
		public IActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public ChangeWeekday()
		{
			this.DayOfWeek = IsoDayOfWeek.Monday;
			this.ActivitySpan = new EmptyActivitySpan();
		}

		/// <inheritdoc />
		public IntermediateDay Apply(IntermediateDay data, GenerationContext context)
		{
			var dayTemplate = context.Template.WeekTemplate.Days[this.DayOfWeek.ToIndex()];
			return context.DayGenerator.Generate(data.Date, dayTemplate, context);
		}
	}
}
