using NodaTime;
using StudentsCalendar.Core.ActivitySpans;
using StudentsCalendar.Core.Intermediates;

namespace StudentsCalendar.Core.Modifiers
{
	/// <summary>
	/// Zmienia podstawowe informacje o zajęciach.
	/// </summary>
	public class ModifyClassesInfo
		: IClassesModifier
	{
		/// <summary>
		/// Pobiera lub zmienia nową godzinę rozpoczęcia.
		/// </summary>
		public LocalTime? StartTime { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nową godzinę zakończenia.
		/// </summary>
		public LocalTime? EndTime { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nową (krótką) nazwę.
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nową pełną nazwę.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Pobiera lub zmienia nowe notatki.
		/// </summary>
		public string Notes { get; set; }

		/// <inheritdoc />
		public IActivitySpan ActivitySpan { get; set; }

		/// <summary>
		/// Inicjalizuje obiekt domyślnymi wartościami.
		/// </summary>
		public ModifyClassesInfo()
		{
			this.ActivitySpan = new EmptyActivitySpan();
		}

		/// <inheritdoc />
		public virtual IntermediateClasses Apply(IntermediateClasses data, GenerationContext context)
		{
			if (this.StartTime.HasValue)
			{
				data.StartDate = data.StartDate.Date.At(this.StartTime.Value);
			}
			if (this.EndTime.HasValue)
			{
				data.EndDate = data.EndDate.Date.At(this.EndTime.Value);
			}
			data.ShortName = this.ShortName ?? data.ShortName;
			data.FullName = this.FullName ?? data.FullName;
			data.Notes = this.Notes ?? data.Notes;
			return data;
		}
	}
}
